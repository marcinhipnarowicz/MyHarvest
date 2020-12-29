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
        private const string getInformationAboutTaskForEmployee = "GetInformationAboutTaskForEmployee";
        private const string getInformationAboutTaskForBoss = "GetInformationAboutTaskForBoss";

        public async static void AddUserInformation(UserInformationVm userInformation)
        {
            var address = Api.BuildAdress(userInformationController, addUserInformation, null, null, "?token=");//
            await Api.Request(RestSharp.Method.POST, address, userInformation);
        }

        public async static Task<List<UserInformationVm>> GetUserInformationListForEmployee(int id)
        {
            var address = Api.BuildAdress(userInformationController, getInformationAboutTaskForEmployee, "?id=", id.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<List<UserInformationVm>>(RestSharp.Method.GET, address);
            return response;
        }

        public async static Task<List<UserInformationVm>> GetUserInformationListForBoss(int id)
        {
            var address = Api.BuildAdress(userInformationController, getInformationAboutTaskForBoss, "?id=", id.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<List<UserInformationVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}