﻿using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public interface IPointOnTheMapService
    {
        List<int> AddPointOnTheMap(List<PointOnTheMapVm> pointOnTheMapVmList);
    }
}