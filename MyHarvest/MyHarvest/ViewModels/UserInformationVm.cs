using System;
using System.Collections.Generic;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class UserInformationVm
    {
        public int IdUserInformation { get; set; }

        //public DbGeography Route { get; set; }
        //public Geography Route { get; set; }//dla tego typu dodany nugget system.Spatial

        public string Area { get; set; }

        public int? IdUser { get; set; }

        public int? IdTask { get; set; }

        public int? IdTaskStatus { get; set; }

        public string UserFistName { get; set; }
        public string UserSurname { get; set; }

        public string UserFullName
        {
            get
            {
                return String.Format($"{UserFistName} {UserSurname}");
            }
        }

        public string StatusOfTaskName { get; set; }

        public string TaskName { get; set; }

        public string TaskDescripton { get; set; }
    }
}