using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("AccountTypes")]
    public class AccountType
    {
        [Key]
        public int IdAccountType { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Users")]
        public int IdAccountTpe { get; set; }

        public User User { get; set; }
    }
}