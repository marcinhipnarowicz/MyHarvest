using MyHarvestApi.Repository;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class UserTaskService : IUserTaskService
    {
        private IUserTaskRepository _repo;

        public UserTaskService(IUserTaskRepository repo)
        {
            _repo = repo;
        }

        public void AddUserTask(UserTaskVm userTaskVm)
        {
            var userTask = UserTaskMapper.MapFromVm(userTaskVm);
            _repo.AddUserTask(userTask);
        }

        public List<UserTaskVm> GetAllInformationAboutTaskList(int id)
        {
            var userTaskList = new List<UserTaskVm>();

            var infoAboutTaskById = _repo.GetInformationAboutTaskList(id);

            if (infoAboutTaskById != null)
                userTaskList = UserTaskMapper.MapList(infoAboutTaskById.ToList());

            return userTaskList;
        }
    }
}