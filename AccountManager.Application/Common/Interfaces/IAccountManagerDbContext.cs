using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Application.Common.Interfaces
{
    public interface IAccountManagerDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
