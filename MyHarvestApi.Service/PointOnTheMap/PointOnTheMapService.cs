using MyHarvestApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class PointOnTheMapService : IPointOnTheMapService
    {
        private IPointOnTheMapRepository _repo;

        public PointOnTheMapService(IPointOnTheMapRepository repo)
        {
            _repo = repo;
        }
    }
}