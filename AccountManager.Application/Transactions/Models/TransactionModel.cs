namespace AccountManager.Application.Transactions.Models
{
    public class TransactionModel
    {
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionTime { get; set; }
    }
}
