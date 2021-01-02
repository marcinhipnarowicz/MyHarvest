using MyHarvestApi.Entity.Context;
using Microsoft.EntityFrameworkCore;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private ApplicationDbContext _db;

        public UserTaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddUserTask(UserTask userTask)
        {
            _db.UsersTasks.Add(userTask);
            _db.SaveChanges();
        }

        public List<UserTask> GetInformationAboutTaskList(int id)
        {
            var infoAboutTaskList = _db.UsersTasks.Where(x => x.IdUser == id).Include(x => x.Task).ToList();
            return infoAboutTaskList;
        }
    }
}