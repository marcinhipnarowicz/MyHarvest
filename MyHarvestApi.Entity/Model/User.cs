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
        public User()
        {
            Replies = new HashSet<User>();
        }

        [Key]
        public int IdUser { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public int IdAccountType { get; set; }

        [ForeignKey("IdAccountType")]
        public virtual AccountType AccountType { get; set; }

        //[ForeignKey("Users")]
        public int? IdBoss { get; set; }

        public virtual User Boss { get; set; }

        public virtual ICollection<User> Replies { get; set; }
    }
}