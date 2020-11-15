using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MyHarvestApi.Entity.Model.Task;

namespace MyHarvestApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private ApplicationDbContext _db;

        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Task> GetTasks()
        {
            var tasksDb = _db.Task.ToList();
            return tasksDb;
        }
    }
}