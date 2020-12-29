using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service.ViewModel
{
    public class UserTaskVm
    {
        public int IdUserTask { get; set; }

        public int? IdUser { get; set; }

        public int? IdTask { get; set; }
    }
}