using MyHarvestApi.Entity.Model;
using MyHarvestApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public class AccountTypeService : IAccountTypeService
    {
        private IAccountTypeRepository _repo;
        private List<AccountType> _accountTypes;

        public AccountTypeService(IAccountTypeRepository repo)
        {
            _repo = repo;
        }

        public List<AccountType> GetAllAccountType()
        {
            _accountTypes = _repo.GetAllAccountType();
            return _accountTypes;
        }
    }
}