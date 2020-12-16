using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHarvestApi.Entity.Model;

namespace MyHarvestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email.Equals(email));//napisz w pracy różnicę pomiędzy == a Equals()
            return user;
        }

        public List<User> GetUsers()
        {
            var usersDb = _db.Users.ToList();
            return usersDb;
        }

        public bool IfExistsUser(string email)
        {
            var check = _db.Users.FirstOrDefault(x => x.Email == email);
            if (check == null)
            {
                return false;
            }
            return true;
        }

        public bool IfExistsBoss(string bossKey)
        {
            var check = _db.Users.FirstOrDefault(x => x.BossKey == bossKey);
            if (check == null)
            {
                return false;
            }
            return true;
        }

        public User GetUserByBossKey(string bossKey)
        {
            if (IfExistsBoss(bossKey))
            {
                var userDb = _db.Users.FirstOrDefault(x => x.BossKey == bossKey);
                if (userDb == null)
                {
                    return null;
                }
                return userDb;
            }
            return null;
        }

        public User GetBossFromUser(int idUser)
        {
            var userDb = _db.Users.FirstOrDefault(x => x.IdUser.Equals(idUser));

            var bossDb = _db.Users.FirstOrDefault(x => x.IdUser.Equals(userDb.IdBoss));

            if (bossDb != null)
            {
                return bossDb;
            }
            return null;
        }

        public List<User> GetUsers(int idUser)
        {
            var usersDb = _db.Users.Where(x => x.IdBoss.Equals(idUser)).ToList();
            return usersDb;
        }

        public int GetMaxId()
        {
            var maxIdUser = _db.Users.OrderByDescending(m => m.IdUser).FirstOrDefault();
            return maxIdUser.IdUser;
        }
    }
}