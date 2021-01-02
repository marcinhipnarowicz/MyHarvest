using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public interface IWaypointRepository
    {
        void AddWaypoint(List<Waypoint> waypointList);

        List<Waypoint> GetWaypointList(int idUserInformation);
    }
}