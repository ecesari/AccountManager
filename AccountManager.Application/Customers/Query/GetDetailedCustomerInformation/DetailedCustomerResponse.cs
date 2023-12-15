using AccountManager.Application.Accounts.Models;
using AccountManager.Domain.Entities;

namespace AccountManager.Application.Customers.Query.GetDetailedCustomerInformation
{
    public class DetailedCustomerResponse
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string TotalBalance { get; set; }
        public List<AccountModel> Accounts { get; set; }

    }
}
