using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHarvestApi.Entity.Model
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public string Email { get; set; }//zmienic na email

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string Name { get; set; }

        [ForeignKey("AccountTypes")]
        public int IdAccountType { get; set; }

        public AccountType AccountType { get; set; }
    }
}