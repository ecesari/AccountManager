namespace AccountManager.Domain.Entities
{
    public class Account : BaseEntity
    {
        public decimal Balance { get; set; }
        public List<BankTransaction> Transactions { get; set; }
        public Customer Customer { get; set; }
    }
}
