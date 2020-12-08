using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api.Controllers.NewToken
{
    public interface IUserManagementService
    {
        bool IsValidUser(string email, string password);
    }
}