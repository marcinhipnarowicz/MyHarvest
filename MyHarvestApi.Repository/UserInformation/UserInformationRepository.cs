using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository.UserInformation
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private ApplicationDbContext _db;

        public UserInformationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}