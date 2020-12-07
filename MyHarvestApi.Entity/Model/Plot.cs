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
    [Table("Plots")]
    public class Plot
    {
        [Key]
        public int IdPlot { get; set; }

        //public DbGeography Coordinates { get; set; }
    }
}