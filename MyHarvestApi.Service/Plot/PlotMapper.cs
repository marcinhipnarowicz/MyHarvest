using MyHarvestApi.Entity.Model;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public static class PlotMapper
    {
        public static Plot MapFromVm(PlotVm plotVm)
        {
            return new Plot
            {
                IdPlot = plotVm.Id
            };
        }

        public static PlotVm MapToVm(Plot plot)
        {
            return new PlotVm
            {
                Id = plot.IdPlot
            };
        }
    }
}