using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AccountManager.Infrastructure.Data;
using AccountManager.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AccountManagerDbContext accountManagerDb) : base(accountManagerDb)
        {

        }

        public async Task<Customer> GetByIdWithDetailedInformation(Guid id)
        {
            var customer = await accountDb.Customers.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task<IReadOnlyList<Customer>> GetAllWithDetailedInformation()
        {
            var customers = await accountDb.Customers.Include(x => x.Accounts).ToListAsync();
            return customers;
        }
    }
}
