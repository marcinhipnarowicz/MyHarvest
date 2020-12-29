using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class UserTaskService

    {
        private const string userTaskController = "UserTask/";
        private const string addUserTask = "AddUserTask";
        private const string getInformationAboutTask = "GetInformationAboutTask";

        public async static void AddUserTask(UserTaskVm userTask)
        {
            var address = Api.BuildAdress(userTaskController, addUserTask, null, null, "?token=");
            await Api.Request(RestSharp.Method.POST, address, userTask);
        }

        public async static Task<List<UserTaskVm>> GetUserTaskList(int id)
        {
            var address = Api.BuildAdress(userTaskController, getInformationAboutTask, "?id=", id.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<List<UserTaskVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}