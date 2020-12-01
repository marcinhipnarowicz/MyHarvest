using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    [Table("UsersTasks")]
    public class UsersTask
    {
        [ForeignKey("Users")]
        public int IdUser { get; set; }

        public User User { get; set; }

        [ForeignKey("Tasks")]
        public int IdTask { get; set; }

        public Task Task { get; set; }
    }
}