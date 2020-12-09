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
        User Authenticate(string email, string password);

        IEnumerable<User> GetAll();

        UserVm GetByEmail(string email);
    }
}