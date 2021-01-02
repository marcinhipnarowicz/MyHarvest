using MyHarvestApi.Repository;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class WaypointService : IWaypointService
    {
        private IWaypointRepository _repo;

        public WaypointService(IWaypointRepository repo)
        {
            _repo = repo;
        }

        public void AddWaypoint(List<WaypointVm> waypointVmList)
        {
            var waypointList = WaypointMapper.MapList(waypointVmList);
            _repo.AddWaypoint(waypointList);
        }

        public List<WaypointVm> GetWaypointList(int idUserInformation)
        {
            var waypointVmList = new List<WaypointVm>();

            var waypointList = _repo.GetWaypointList(idUserInformation);

            if (waypointList != null)
                waypointVmList = WaypointMapper.MapListToVm(waypointList.ToList());

            return waypointVmList;
        }
    }
}