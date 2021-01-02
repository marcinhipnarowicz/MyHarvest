using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class UserInformationVm
    {
        public int IdUserInformation { get; set; }

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

        public Color ColorText
        {
            get
            {
                switch (IdTaskStatus)
                {
                    case 1:
                        return Color.Red;

                    case 2:
                        return Color.Yellow;

                    case 3:
                        return Color.Green;

                    default:
                        return Color.White;
                }
            }
        }

        public string StatusOfTaskName { get; set; }

        public string TaskName { get; set; }

        public string TaskDescripton { get; set; }
    }
}