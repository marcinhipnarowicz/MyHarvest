using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class UserInformationMapper
    {
        public static UserInformation MapFromVm(UserInformationVm usInfoVm)
        {
            return new UserInformation
            {
                IdUserInformation = usInfoVm.IdUserInformation,
                IdTask = usInfoVm.IdTask,
                IdTaskStatus = usInfoVm.IdTaskStatus,
                IdUser = usInfoVm.IdUser,
                Area = usInfoVm.Area

                //taskName, TaskDescription
            };
        }

        public static List<UserInformationVm> MapList(List<UserInformation> userInformation)
        {
            var userInformationList = new List<UserInformationVm>();

            foreach (var item in userInformation)
            {
                var userInfo = new UserInformationVm();

                userInfo.IdUserInformation = item.IdUserInformation;
                userInfo.IdTask = item.IdTask;
                userInfo.IdUser = item.IdUser;
                userInfo.IdTaskStatus = item.IdTaskStatus;
                userInfo.Area = item.Area;

                userInfo.UserFistName = item.User.FirstName;
                userInfo.UserSurname = item.User.Surname;
                userInfo.TaskName = item.Task.Name;
                userInfo.TaskDescripton = item.Task.Description;
                userInfo.StatusOfTaskName = item.StatusOfTask.Name;

                userInformationList.Add(userInfo);
            }

            return userInformationList;
        }
    }
}