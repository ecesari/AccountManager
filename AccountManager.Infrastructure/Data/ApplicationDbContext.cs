﻿using AccountManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Data
{
    public class AccountManagerDbContext : DbContext
    {
        public AccountManagerDbContext(DbContextOptions<AccountManagerDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankTransaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<BankTransaction>().HasKey(t => t.Id);

            modelBuilder.Entity<Customer>().HasMany(c => c.Accounts).WithOne(a => a.Customer);
            modelBuilder.Entity<Account>().HasMany(a => a.Transactions).WithOne(a => a.Account);

            modelBuilder.Entity<Customer>().HasData(new Customer { LastName = "User", Name = "Test", Id = Guid.NewGuid() });
        }
    }
}
