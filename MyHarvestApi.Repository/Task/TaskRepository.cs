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

        public void Add(Task task)
        {
            _db.Task.Add(task);
            _db.SaveChanges();
        }

        public void EditTask(int id, Task task)
        {
            _db.Entry(task).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public Task GetOneTask(int id)
        {
            var task = _db.Task.FirstOrDefault(x => x.IdTask == id);
            return task;
        }

        public List<Task> GetTasks()
        {
            var tasksDb = _db.Task.ToList();
            return tasksDb;
        }

        public bool IfTaskExist(int id)
        {
            throw new NotImplementedException();
        }

        private bool MovieExists(long id) =>
         _db.Task.Any(e => e.IdTask == id);
    }
}