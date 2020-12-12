using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class AccountTypeService
    {
        private const string accountTypeController = "AccountType/";
        private const string get_all_accountType = "GetAccountType";

        public static async Task<List<AccountTypeVm>> GetAccountTypeList()
        {
            var address = Api.BuildAdress(accountTypeController, get_all_accountType);
            var response = await Api.RequestAndSerialize<List<AccountTypeVm>>(RestSharp.Method.GET, address);
            return response;
        }
    }
}