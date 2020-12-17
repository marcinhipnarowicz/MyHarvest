using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class StatusOfTaskService
    {
        private const string statusOfTaskController = "StatusOfTask/";
        private const string get_all_statusOfTask = "GetStatusOfTask";

        public static async Task<List<StatusOfTaskVm>> GetStatusOfTaskList()
        {
            var address = Api.BuildAdress(statusOfTaskController, get_all_statusOfTask, null, null);//, "&token="
            var response = await Api.RequestAndSerialize<List<StatusOfTaskVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}