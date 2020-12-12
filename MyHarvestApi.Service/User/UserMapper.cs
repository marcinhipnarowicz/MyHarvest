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
            //userVm.BossKey = user.BossKey;
            userVm.IdAccountType = user.IdAccountType;

            if (user.IdBoss != null)
            {
                userVm.IdBoss = (int)user.IdBoss;
            }

            return userVm;

            //return new UserVm
            //{
            //    Id = user.IdUser,
            //    Email = user.Email,
            //    Password = user.Password,
            //    FirstName = user.FirstName,
            //    Surename = user.FirstName,
            //    IdAccountType = user.IdAccountType,
            //    IdBoss = (int)user.IdBoss
            //};
        }
    }
}