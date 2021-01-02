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
        private const string getWaipoints = "GetWaypoints";

        public async static void AddWaypoint(WaypointListVm waypointList)
        {
            var address = Api.BuildAdress(waypointController, addWaipoint, null, null, "?token=");
            await Api.Request(RestSharp.Method.POST, address, waypointList);
        }

        public async static Task<List<WaypointVm>> GetWaypoints(int idUserInformation)
        {
            var address = Api.BuildAdress(waypointController, getWaipoints, "?idUserInformation=", idUserInformation.ToString(), "&token=");
            var response = await Api.RequestAndSerialize<List<WaypointVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}