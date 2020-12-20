using MyHarvestApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public void AddTask(TaskVm taskVm)
        {
            var task = TaskMapper.MapFromVm(taskVm);
            _repo.AddTask(task);
        }

        public int GetMaxId()
        {
            int maxId = _repo.GetMaxId();
            return maxId;
        }
    }
}