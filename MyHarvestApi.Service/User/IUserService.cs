using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public interface IUserService
    {
        string Authenticate(string email);

        IEnumerable<User> GetAll();

        UserVm GetByEmail(string email);

        void AddUser(UserVm userVm);

        bool IfExistsUser(string email);

        bool IfExistsBoss(string bossKey);

        string GetBossKey();

        string RandomBossKey();
    }
}