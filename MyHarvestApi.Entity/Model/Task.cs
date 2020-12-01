using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int IdTask { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Plots")]
        public int IdPlot { get; set; }

        public Plot Plot { get; set; }
    }
}