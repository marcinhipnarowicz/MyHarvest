using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository.Plot
{
    public class PlotRepository : IPlotRepository
    {
        private ApplicationDbContext _db;

        public PlotRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}