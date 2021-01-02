using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public interface IUserService
    {
        string Authenticate(string email);

        IEnumerable<User> GetAll();

        List<UserVm> GetEmployeeForBoss(int idUser);

        UserVm GetBossFromUser(int idUser);

        UserVm GetByEmail(string email);

        int AddUser(UserVm userVm);

        bool IfExistsUser(string email);

        bool IfExistsBoss(string bossKey);

        string GetBossKey();

        string RandomBossKey();

        int GetIdBoss(string bossKey);

        string GetHash(HashAlgorithm hashAlgorithm, string password);

        int GetMaxId();

        void RemoveBossOfEmployee(int id);

        void AddNewBossForEmployee(UserVm userVm, int id);
    }
}