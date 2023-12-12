namespace AccountManager.Application.Customers.Query.GetDetailedCustomerInformation
{
    public class AccountModel
    {
        public decimal Balance { get; set; }
        List<TransactionModel> Transactions { get; set; }
    }
}
