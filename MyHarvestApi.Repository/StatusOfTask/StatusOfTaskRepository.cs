using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class StatusOfTaskRepository : IStatusOfTaskRepository
    {
        private ApplicationDbContext _db;

        public StatusOfTaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<StatusOfTask> GetAllAStatusOfTask()
        {
            var statusOfTaskdb = _db.StatusOfTasks.ToList();
            return statusOfTaskdb;
        }
    }
}