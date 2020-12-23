using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        List<User> GetUsers(int idUser);

        User GetBossFromUser(int idUser);

        User GetUserByEmail(string email);

        User GetUserById(int id);

        void AddUser(User user);

        void EditUser(User user);

        bool IfExistsUser(string email);

        bool IfExistsBoss(string bossKey);

        User GetUserByBossKey(string bossKey);

        int GetMaxId();
    }
}