using System;
using System.Collections.Generic;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class WaypointVm
    {
        public int IdWaypoint { get; set; }

        public int? IdUserInformation { get; set; }
        public int? IdPointOnTheMap { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
    }
}