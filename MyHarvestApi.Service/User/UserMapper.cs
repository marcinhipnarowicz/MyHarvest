using MyHarvestApi.Service.ViewModel;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class UserMapper
    {
        public static UserVm MapToVm(User user)
        {
            UserVm userVm = new UserVm();

            userVm.Id = user.IdUser;
            userVm.Email = user.Email;
            userVm.Password = user.Password;
            userVm.FirstName = user.FirstName;
            userVm.Surname = user.Surname;
            userVm.BossKey = user.BossKey;
            userVm.IdAccountType = user.IdAccountType;

            if (user.IdBoss != null)
            {
                userVm.IdBoss = (int)user.IdBoss;
            }

            return userVm;
        }

        public static User MapFromVm(UserVm userVm)
        {
            return new User
            {
                IdUser = userVm.Id,
                Email = userVm.Email,
                Password = userVm.Password,
                FirstName = userVm.FirstName,
                Surname = userVm.Surname,
                BossKey = userVm.BossKey,
                IsVerified = userVm.IsVerified,
                IdAccountType = userVm.IdAccountType,
                IdBoss = userVm.IdBoss
            };
        }
    }
}