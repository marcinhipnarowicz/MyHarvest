using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("Waypoints")]
    public class Waypoint
    {
        [Key]
        public int IdWaypoint { get; set; }

        public int? IdUserInformation { get; set; }

        [ForeignKey("IdUserInformation")]
        public virtual UserInformation UserInformation { get; set; }

        public int? IdPointOnTheMap { get; set; }

        [ForeignKey("IdPointOnTheMap")]
        public virtual PointOnTheMap PointOnTheMap { get; set; }
    }
}