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

        public int AddTask(TaskVm taskVm)
        {
            var task = TaskMapper.MapFromVm(taskVm);
            _repo.AddTask(task);
            var idTask = task.IdTask;

            return idTask;
        }

        public void EditTask(TaskVm taskVm)
        {
            var task = TaskMapper.MapFromVm(taskVm);
            _repo.EditTask(task);
        }

        public int GetMaxId()
        {
            int maxId = _repo.GetMaxId();
            return maxId;
        }

        public void RemoveTask(int id)
        {
            var task = _repo.GetOneTask(id);

            if (task != null)
            {
                _repo.RemoveTask(task);
            }
        }
    }
}