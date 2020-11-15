using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;

//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Context
{
    public class ApplicationDbContext //: DbContext
    {
        //public MobileServiceClient client = new MobileServiceClient("https://myharvestapp.azurewebsites.net");

        public ApplicationDbContext(string connectionString) //: base(connectionString)
        {
            //System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(null);
        }

        // public DbSet<Users> Users { get; set; }
    }
}