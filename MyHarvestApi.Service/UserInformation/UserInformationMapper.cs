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
            };
        }
    }
}