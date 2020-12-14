using MyHarvestApi.Entity.Model;
using MyHarvestApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class StatusOfTaskService : IStatusOfTaskService
    {
        private IStatusOfTaskRepository _repo;
        private List<StatusOfTask> _statusOfTasks;

        public StatusOfTaskService(IStatusOfTaskRepository repo)
        {
            _repo = repo;
        }

        public List<StatusOfTask> GetAllStatusOfTask()
        {
            _statusOfTasks = _repo.GetAllAStatusOfTask();
            return _statusOfTasks;
        }
    }
}