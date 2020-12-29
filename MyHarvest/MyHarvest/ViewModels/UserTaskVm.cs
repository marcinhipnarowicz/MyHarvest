using System;
using System.Collections.Generic;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class UserTaskVm
    {
        public int IdUserTask { get; set; }

        public int? IdUser { get; set; }

        public int? IdTask { get; set; }
    }
}