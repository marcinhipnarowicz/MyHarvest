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
        private const string register = "Register";
        private const string getUserFromBoss = "GetForBoss";

        public async static Task<LoginVm> Login(LoginVm user)
        {
            var address = Api.LoginAdress(userControler, login);
            var response = await Api.RequestAndSerialize<LoginVm>(RestSharp.Method.POST, address, user);

            return response;
        }

        public async static Task<UserVm> Register(UserVm user)
        {
            var address = Api.LoginAdress(userControler, register);
            var response = await Api.RequestAndSerialize<UserVm>(RestSharp.Method.POST, address, user);
            return response;
        }

        public async static Task<List<UserVm>> GeUserFromBossList()
        {
            var address = Api.BuildAdress(userControler, getUserFromBoss);
            var response = await Api.RequestAndSerialize<List<UserVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}