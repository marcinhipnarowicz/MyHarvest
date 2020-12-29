using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class UserTaskMapper
    {
        public static UserTask MapFromVm(UserTaskVm userTaskVm)
        {
            return new UserTask
            {
                IdTask = userTaskVm.IdTask,
                IdUser = userTaskVm.IdUser
            };
        }

        public static List<UserTaskVm> MapList(List<UserTask> userTasksList)
        {
            var userTaskList = new List<UserTaskVm>();

            foreach (var item in userTasksList)
            {
                var userTask = new UserTaskVm();

                userTask.IdUserTask = item.IdUserTask;
                userTask.IdTask = item.IdTask;
                userTask.IdUser = item.IdUser;

                userTaskList.Add(userTask);
            }

            return userTaskList;
        }
    }
}