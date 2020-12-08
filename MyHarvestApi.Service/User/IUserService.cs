using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = MyHarvestApi.Entity.Model.User;

namespace MyHarvestApi.Service
{
    public interface IUserService
    {
        User Authenticate(string email, string password);

        IEnumerable<User> GetAll();
    }
}