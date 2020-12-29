using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Spatial;
using System.Linq;
using System.Spatial;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("Plots")]
    public class Plot
    {
        [Key]
        public int IdPlot { get; set; }

        public string Name { get; set; }

        //public NetTopologySuite.Geometries.Geometry Coordinates { get; set; }

        public DbGeography Coordinates { get; set; }

        //public Geography Coordinates { get; set; }//dla tego typu dodany nugget system.Spatial
    }
}