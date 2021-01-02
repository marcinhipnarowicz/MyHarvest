using MyHarvestApi.Repository;
using MyHarvestApi.Service.ViewModel;
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

        public void AddPointOnTheMap(List<PointOnTheMapVm> pointOnTheMapVmList)
        {
            var pointOnTheMapList = PointOnTheMapMapper.MapList(pointOnTheMapVmList);
            _repo.AddPointOnTheMap(pointOnTheMapList);
        }
    }
}