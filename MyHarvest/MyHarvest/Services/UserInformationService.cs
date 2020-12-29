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
        private const string getInformationAboutTask = "GetInformationAboutTask";

        public async static void AddUserInformation(UserInformationVm userInformation)
        {
            var address = Api.BuildAdress(userInformationController, addUserInformation, null, null, "?token=");//
            await Api.Request(RestSharp.Method.POST, address, userInformation);
        }

        public async static Task<List<UserInformationVm>> GetUserInformationList(int id)
        {
            var address = Api.BuildAdress(userInformationController, getInformationAboutTask, "?id=", id.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<List<UserInformationVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}