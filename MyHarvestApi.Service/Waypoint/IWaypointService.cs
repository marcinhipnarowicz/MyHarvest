using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public interface IWaypointService
    {
        void AddWaypoint(List<WaypointVm> waypointVmList);

        List<WaypointVm> GetWaypointList(int idUserInformation);
    }
}