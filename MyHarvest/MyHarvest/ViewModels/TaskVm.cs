using System;
using System.Collections.Generic;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class TaskVm
    {
        public int IdTask { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? IdPlot { get; set; }
    }
}