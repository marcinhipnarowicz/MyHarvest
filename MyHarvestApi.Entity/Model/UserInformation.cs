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
    [Table("UsersInformation")]
    public class UserInformation
    {
        [Key]
        public int IdUserInformation { get; set; }

        public string Area { get; set; }

        public int? IdUser { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        public int? IdTask { get; set; }

        [ForeignKey("IdTask")]
        public virtual Task Task { get; set; }

        public int? IdTaskStatus { get; set; }

        [ForeignKey("IdTaskStatus")]
        public virtual StatusOfTask StatusOfTask { get; set; }
    }
}