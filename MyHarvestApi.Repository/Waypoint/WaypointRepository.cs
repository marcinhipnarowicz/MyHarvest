using Microsoft.EntityFrameworkCore;
using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
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

        public void AddWaypoint(List<Waypoint> waypointList)
        {
            foreach (var item in waypointList)
            {
                _db.Waypoints.Add(item);
            }

            _db.SaveChanges();
        }

        public List<Waypoint> GetWaypointList(int idUserInformation)
        {
            var temp = _db.Waypoints.FirstOrDefault(x => x.IdUserInformation.Equals(idUserInformation));
            if (temp != null)
            {
                var waypointList = _db.Waypoints.Where(x => x.UserInformation.IdUserInformation == idUserInformation)
                                                        .Include(x => x.PointOnTheMap).ToList();

                return waypointList;
            }
            else
                return null;
        }
    }
}