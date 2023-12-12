namespace AccountManager.Domain.Entities
{
    public class BankTransaction :BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionTime { get; set; }
        public Account Account { get; set; }
    }
}
