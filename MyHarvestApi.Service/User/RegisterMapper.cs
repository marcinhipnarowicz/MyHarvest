using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class RegisterMapper
    {
        public static RegisterVm MapToVm(UserVm user)
        {
            return new RegisterVm
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                Surname = user.Surname,
                BossKey = user.BossKey,
                IsVerified = user.IsVerified,
                IdAccountType = user.IdAccountType,
                IdBoss = user.IdBoss,
            };
        }
    }
}