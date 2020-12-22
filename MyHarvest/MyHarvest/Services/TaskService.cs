using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class TaskService
    {
        private const string taskController = "Task/";
        private const string addTask = "AddTask";

        public async static Task<TaskVm> AddTask(TaskVm task)
        {
            var address = Api.BuildAdress(taskController, addTask, null, null, "?token=");//
            var response = await Api.RequestAndSerialize<TaskVm>(RestSharp.Method.POST, address, task);
            return response;
        }
    }
}