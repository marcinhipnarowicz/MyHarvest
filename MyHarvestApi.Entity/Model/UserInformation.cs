using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("UsersInformation")]
    public class UserInformation
    {
        [Key]
        public int IdUserInformation { get; set; }

        public DbGeography Route { get; set; }

        public string Area { get; set; }

        [ForeignKey("Users")]
        public int IdUser { get; set; }

        public User User { get; set; }

        [ForeignKey("Tasks")]
        public int IdTask { get; set; }

        public Task Task { get; set; }

        [ForeignKey("StatusOfTasks")]
        public int IdTaskStatus { get; set; }

        public StatusOfTask StatusOfTask { get; set; }
    }
}