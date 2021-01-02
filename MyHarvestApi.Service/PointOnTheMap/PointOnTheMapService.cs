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

        public List<int> AddPointOnTheMap(List<PointOnTheMapVm> pointOnTheMapVmList)
        {
            var pointOnTheMapList = PointOnTheMapMapper.MapList(pointOnTheMapVmList);
            _repo.AddPointOnTheMap(pointOnTheMapList);

            List<int> idPointsList = new List<int>();

            foreach (var item in pointOnTheMapList)
            {
                idPointsList.Add(item.IdPointOnTheMap);
            }
            return idPointsList;
        }
    }
}