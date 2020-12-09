using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class UserService
    {
        private const string userControler = "User/";
        private const string login = "Login";

        public async static Task<LoginVm> Login(LoginVm user)
        {
            var address = Api.LoginAdress(userControler, login);
            var response = await Api.RequestAndSerialize<LoginVm>(RestSharp.Method.POST, address, user);

            return response;
        }
    }
}