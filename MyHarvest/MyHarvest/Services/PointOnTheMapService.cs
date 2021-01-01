using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class PointOnTheMapService
    {
        private const string pointOnTheMapController = "PointOnTheMap/";
        private const string addPointOnTheMap = "AddPointOnTheMap";

        public async static Task<List<PointOnTheMapListVm>> AddPointOnTheMap(PointOnTheMapListVm pointOnTheMapList)
        {
            var address = Api.BuildAdress(pointOnTheMapController, addPointOnTheMap, null, null, "?token=");//
            var response = await Api.RequestAndSerialize<List<PointOnTheMapListVm>>(RestSharp.Method.POST, address, pointOnTheMapList);
            return response;
        }
    }
}