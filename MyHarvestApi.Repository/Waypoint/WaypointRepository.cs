using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class WaypointRepository : IWaypointRepository
    {
        private ApplicationDbContext _db;

        public WaypointRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}