using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class WaypointMapper
    {
        public static List<Waypoint> MapList(List<WaypointVm> waypointVm)
        {
            var waypointList = new List<Waypoint>();

            foreach (var item in waypointVm)
            {
                var waypoint = new Waypoint();

                waypoint.IdWaypoint = item.IdWaypoint;
                waypoint.IdPointOnTheMap = item.IdPointOnTheMap;
                waypoint.IdUserInformation = item.IdUserInformation;

                waypointList.Add(waypoint);
            }

            return waypointList;
        }

        public static List<WaypointVm> MapListToVm(List<Waypoint> waypoint)
        {
            var waypointVmList = new List<WaypointVm>();

            foreach (var item in waypoint)
            {
                var waypointVm = new WaypointVm();

                waypointVm.IdWaypoint = item.IdWaypoint;
                waypointVm.IdPointOnTheMap = item.IdPointOnTheMap;
                waypointVm.IdUserInformation = item.IdUserInformation;

                waypointVmList.Add(waypointVm);
            }

            return waypointVmList;
        }
    }
}