namespace AccountManager.Domain.Entities
{
    public class Transaction :BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionTime { get; set; }
        public Account Account { get; set; }
    }
}
