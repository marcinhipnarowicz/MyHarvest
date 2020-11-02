using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Model
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int IdUser { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public int AccountType { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }

    public enum AccountType
    {
        Invalid = 0,
        Boss,
        Employee,
    }
}