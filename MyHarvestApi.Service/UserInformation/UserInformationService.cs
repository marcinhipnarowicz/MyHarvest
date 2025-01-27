﻿using MyHarvestApi.Entity.Model;
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

        public void EditUserInformation(UserInformationVm userInformationVm)
        {
            var userInformation = UserInformationMapper.MapFromVm(userInformationVm);
            _repo.EditUserInformation(userInformation);
        }

        public List<UserInformationVm> GetAllInformationAboutTaskListForBoss(int id)
        {
            var userInformationList = new List<UserInformationVm>();

            var infoAboutTaskById = _repo.GetInformationAboutTaskListForBoss(id);

            if (infoAboutTaskById != null)
                userInformationList = UserInformationMapper.MapList(infoAboutTaskById.ToList());

            return userInformationList;
        }

        public List<UserInformationVm> GetAllInformationAboutTaskListForEmployee(int id)
        {
            var userInformationList = new List<UserInformationVm>();

            var infoAboutTaskById = _repo.GetInformationAboutTaskListForEmployee(id);

            if (infoAboutTaskById != null)
                userInformationList = UserInformationMapper.MapList(infoAboutTaskById.ToList());

            return userInformationList;
        }
    }
}