using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service.ViewModel
{
    public class LoginVm
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IdAccountType { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}