using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("PointsOnTheMap")]
    public class PointOnTheMap
    {
        [Key]
        public int IdPointOnTheMap { get; set; }

        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
    }
}