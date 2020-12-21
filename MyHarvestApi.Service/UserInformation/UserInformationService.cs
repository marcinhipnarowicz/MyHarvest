using MyHarvestApi.Repository;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class UserInformationService : IUserInformationService
    {
        private IUserInformationRepository _repo;

        public UserInformationService(IUserInformationRepository repo)
        {
            _repo = repo;
        }

        public void AddUserInformation(UserInformationVm userInformationVm)
        {
            var userInformation = UserInformationMapper.MapFromVm(userInformationVm);
            _repo.AddUserInformation(userInformation);
        }
    }
}