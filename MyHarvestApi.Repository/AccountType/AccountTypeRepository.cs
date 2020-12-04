using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository.AccountType
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private ApplicationDbContext _db;

        public AccountTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}