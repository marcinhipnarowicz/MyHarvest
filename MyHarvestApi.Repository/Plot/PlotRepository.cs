using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class PlotRepository : IPlotRepository
    {
        private ApplicationDbContext _db;

        public PlotRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddPlot(Plot plot)
        {
            _db.Plots.Add(plot);
            _db.SaveChanges();
        }
    }
}