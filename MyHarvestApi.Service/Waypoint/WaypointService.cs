using MyHarvestApi.Repository;
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
    }
}