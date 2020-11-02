using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Entity.Context
{
    public class ApplicationDbContext
    {
        public MobileServiceClient client = new MobileServiceClient("https://myharvestapp.azurewebsites.net");
    }
}