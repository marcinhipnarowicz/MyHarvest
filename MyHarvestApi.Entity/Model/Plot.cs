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

        public string AreaPlot { get; set; }

        public string Route { get; set; }

        public DbGeography Location { get; set; }

        [ForeignKey("Tasks")]
        public int IdTask { get; set; }

        public Task Task { get; set; }
    }
}