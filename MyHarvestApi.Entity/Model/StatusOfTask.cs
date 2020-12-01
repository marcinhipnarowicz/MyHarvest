using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("StatusOfTasks")]
    public class StatusOfTask
    {
        [Key]
        public int IdStatus { get; set; }

        [Required]
        public string Name { get; set; }
    }
}