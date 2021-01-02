using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class PointOnTheMapMapper
    {
        public static List<PointOnTheMap> MapList(List<PointOnTheMapVm> pointOnTheMapVm)
        {
            var pointOnTheMapList = new List<PointOnTheMap>();

            foreach (var item in pointOnTheMapVm)
            {
                var pointOnTheMap = new PointOnTheMap();

                pointOnTheMap.IdPointOnTheMap = item.IdPointOnTheMap;
                pointOnTheMap.XCoordinate = item.XCoordinate;
                pointOnTheMap.YCoordinate = item.YCoordinate;

                pointOnTheMapList.Add(pointOnTheMap);
            }

            return pointOnTheMapList;
        }

        public static List<PointOnTheMapVm> MapListToVm(List<PointOnTheMap> pointOnTheMapVm2)
        {
            var pointOnTheMapVmList = new List<PointOnTheMapVm>();

            foreach (var item in pointOnTheMapVm2)
            {
                var pointOnTheMapVm = new PointOnTheMapVm();

                pointOnTheMapVm.IdPointOnTheMap = item.IdPointOnTheMap;
                pointOnTheMapVm.XCoordinate = item.XCoordinate;
                pointOnTheMapVm.YCoordinate = item.YCoordinate;

                pointOnTheMapVmList.Add(pointOnTheMapVm);
            }

            return pointOnTheMapVmList;
        }
    }
}