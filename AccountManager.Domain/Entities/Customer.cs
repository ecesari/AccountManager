namespace AccountManager.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
