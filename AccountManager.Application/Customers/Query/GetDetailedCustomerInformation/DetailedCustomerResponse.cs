using AccountManager.Domain.Entities;

namespace AccountManager.Application.Customers.Query.GetDetailedCustomerInformation
{
    public class DetailedCustomerResponse
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public List<Account> Accounts { get; set; }

    }
}
