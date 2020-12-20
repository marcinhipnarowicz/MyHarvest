using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class UserInformationService
    {
        private const string userInformationController = "UserInformation/";
        private const string addUserInformation = "AddUserInformation";

        public async static Task<UserInformationVm> AddTask(UserInformationVm userInformation)
        {
            var address = Api.LoginAdress(userInformationController, addUserInformation);
            var response = await Api.RequestAndSerialize<UserInformationVm>(RestSharp.Method.POST, address, userInformation);
            return response;
        }
    }
}