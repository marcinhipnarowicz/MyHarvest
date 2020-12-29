using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public interface IUserInformationService
    {
        void AddUserInformation(UserInformationVm userInformationVm);

        List<UserInformationVm> GetAllInformationAboutTaskListForEmployee(int id);

        List<UserInformationVm> GetAllInformationAboutTaskListForBoss(int id);
    }
}