using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class TaskVm
    {
        public int IdTask { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? IdPlot { get; set; }
    }
}