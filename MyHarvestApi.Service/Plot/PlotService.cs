using MyHarvestApi.Repository;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class PlotService : IPlotService
    {
        private IPlotRepository _repo;

        public PlotService(IPlotRepository repo)
        {
            _repo = repo;
        }

        public void AddPlot(PlotVm plotVm)
        {
            var plot = PlotMapper.MapFromVm(plotVm);
            _repo.AddPlot(plot);
        }
    }
}