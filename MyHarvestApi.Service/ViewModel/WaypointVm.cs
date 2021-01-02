using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service.ViewModel
{
    public class WaypointVm
    {
        public int IdWaypoint { get; set; }

        public int? IdUserInformation { get; set; }

        public int? IdPointOnTheMap { get; set; }
    }
}