﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyHarvestApi.Entity.AppSettingsHelp;
using MyHarvestApi.Entity.Model;
using MyHarvestApi.Repository;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;

        private readonly AppSettings _appSettings;

        private List<User> _users;

        public UserService(IUserRepository repo, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _users = _repo.GetUsers();
            _appSettings = appSettings.Value;
        }

        public string Authenticate(string email)
        {
            var user = _users.SingleOrDefault(x => x.Email.Equals(email));
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IdUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public UserVm GetByEmail(string email)
        {
            User user = _repo.GetUserByEmail(email);
            if (user == null)
                return null;

            UserVm userVm = UserMapper.MapToVm(user);
            return userVm;
        }

        public void AddUser(UserVm userVm)
        {
            var user = UserMapper.MapFromVm(userVm);
            _repo.AddUser(user);
        }

        public bool IfExistsUser(string email)
        {
            var check = _repo.IfExistsUser(email);
            return check;
        }

        public string RandomBossKey()
        {
            var chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rand = new Random();

            var result = new string(
        Enumerable.Repeat(chars, 6)
                    .Select(s => s[rand.Next(s.Length)])
                    .ToArray());

            return result;
        }

        public string GetBossKey()
        {
            bool badKey = false;
            string result;

            do
            {
                result = RandomBossKey();

                if (IfExistsBoss(result))
                    badKey = true;
            } while (badKey);

            return result;
        }

        public bool IfExistsBoss(string bossKey)
        {
            var check = _repo.IfExistsBoss(bossKey);
            return check;
        }

        public string GetHash(HashAlgorithm hashAlgorithm, string password)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

            var sBuilder = new StringBuilder(); //nowy string builder aby zebrac bajty i utworzyć ciąg

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();//zwraca hexadecymalny string
        }

        public bool VeryfiHash(HashAlgorithm hashAlgorithm, string password, string hash)
        {
            var hashOfPassword = GetHash(hashAlgorithm, password);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase; //tworzenie StringCompareer w celu porownania z hashowanym

            return comparer.Compare(hashOfPassword, hash) == 0;
        }
    }
}