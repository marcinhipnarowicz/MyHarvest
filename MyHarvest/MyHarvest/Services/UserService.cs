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
        private const string getBossForUser = "GetBossForUser";
        private const string getUser = "GetUser";
        private const string removeBossOfEmployee = "RemoveBossOfEmployee";

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

        public async static Task<List<UserVm>> GeUserFromBossList(int idUser)
        {
            var address = Api.BuildAdress(userControler, getUserFromBoss, "?idBoss=", idUser.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<List<UserVm>>(RestSharp.Method.GET, address);
            return response;
        }

        public async static Task<UserVm> GetBossFormUser(int idUser)
        {
            var address = Api.BuildAdress(userControler, getBossForUser, "?idUser=", idUser.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<UserVm>(RestSharp.Method.GET, address);
            return response;
        }

        public async static Task<UserVm> GetUser(string email)
        {
            var address = Api.BuildAdress(userControler, getUser, "?email=", email, "&token=");
            var response = await Api.RequestAndSerialize<UserVm>(RestSharp.Method.GET, address);
            return response;
        }

        public async static void RemoveBossOfEmployee(int id)
        {
            var adress = Api.BuildAdress(userControler, removeBossOfEmployee, "?id=", id.ToString());
            await Api.Request(RestSharp.Method.POST, adress);
        }
    }
}