using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service.ViewModel
{
    public class UserInformationVm
    {
        public int IdUserInformation { get; set; }

        public string Area { get; set; }

        public int? IdUser { get; set; }

        public int? IdTask { get; set; }

        public int? IdTaskStatus { get; set; }
    }
}