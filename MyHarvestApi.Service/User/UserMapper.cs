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
        public static UserVm Map(User user)
        {
            return new UserVm
            {
                Id = user.IdUser,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                Surename = user.FirstName
            };
        }
    }
}