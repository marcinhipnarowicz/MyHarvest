using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private ApplicationDbContext _db;

        public AccountTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        List<AccountType> IAccountTypeRepository.GetAllAccountType()
        {
            var accountTypedb = _db.AccountTypes.ToList();
            return accountTypedb;
        }
    }
}