using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class PointOnTheMapRepository : IPointOnTheMapRepository
    {
        private ApplicationDbContext _db;

        public PointOnTheMapRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddPointOnTheMap(List<PointOnTheMap> pointOnTheMapList)
        {
            foreach (var item in pointOnTheMapList)
            {
                _db.PointsOnTheMap.Add(item);
            }

            _db.SaveChanges();
        }
    }
}