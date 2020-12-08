using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("UsersTasks")]
    public class UserTask
    {
        [Key]
        public int IdUserTask { get; set; }

        public int? IdUser { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        public int? IdTask { get; set; }

        [ForeignKey("IdTask")]
        public virtual Task Task { get; set; }
    }
}