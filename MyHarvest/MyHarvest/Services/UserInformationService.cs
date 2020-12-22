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

        public async static void AddUserInformation(UserInformationVm userInformation)
        {
            var address = Api.BuildAdress(userInformationController, addUserInformation, null, null, "&token=");//
            await Api.Request(RestSharp.Method.POST, address, userInformation);
        }
    }
}