using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public class WaypointService
    {
        private const string waypointController = "Waypoint/";
        private const string addWaipoint = "AddWaypoint";

        public async static void AddWaypoint(WaypointListVm waypointList)
        {
            var address = Api.BuildAdress(waypointController, addWaipoint, null, null, "?token=");
            await Api.Request(RestSharp.Method.POST, address, waypointList);
        }
    }
}