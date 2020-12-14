using System;
using System.Collections.Generic;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class UserVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsVerified { get; set; }
        public string BossKey { get; set; }

        //public string Token { get; set; }
        public int IdAccountType { get; set; }

        public int? IdBoss { get; set; }
    }
}