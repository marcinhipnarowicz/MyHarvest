using Microsoft.EntityFrameworkCore;
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

        public void AddTask(Task task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void EditTask(int id, Task task)
        {
            _db.Entry(task).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public int GetMaxId()
        {
            var maxIdTask = _db.Tasks.OrderByDescending(t => t.IdTask).FirstOrDefault();
            return maxIdTask.IdTask;
        }

        public Task GetOneTask(int id)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.IdTask == id);
            return task;
        }

        public List<Task> GetTasks()
        {
            var tasksDb = _db.Tasks.ToList();
            return tasksDb;
        }

        public bool IfTaskExist(int id)
        {
            throw new NotImplementedException();
        }

        private bool MovieExists(long id) =>
         _db.Tasks.Any(e => e.IdTask == id);
    }
}