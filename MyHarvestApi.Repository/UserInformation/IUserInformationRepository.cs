using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public interface IUserInformationRepository
    {
        void AddUserInformation(UserInformation userInformation);

        List<UserInformation> GetInformationAboutTaskListForEmployee(int id);

        List<UserInformation> GetInformationAboutTaskListForBoss(int id);
    }
}