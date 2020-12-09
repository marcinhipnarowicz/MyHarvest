using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class LoginMapper
    {
        public static LoginVm Map(User user)
        {
            return new LoginVm
            {
                Email = user.Email,
                Password = user.Password
            };

            //return new LoginVm // w metodzie przekazywać jeszcze , string token
            //{
            //    Id = user.IdUser,
            //    Email = user.Email,
            //    Password = user.Password,
            //    Token = token
            //};
        }
    }
}