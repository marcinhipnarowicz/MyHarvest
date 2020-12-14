using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service.ViewModel
{
    public class RegisterVm
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsVerified { get; set; }
        public string BossKey { get; set; }

        public int IdAccountType { get; set; }

        public int? IdBoss { get; set; }
        public string Token { get; set; }
    }
}