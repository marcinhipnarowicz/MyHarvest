using MyHarvestApi.Entity.Context;
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
    }
}