using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AccountManager.Infrastructure.Data;
using AccountManager.Infrastructure.Repository.Base;

namespace AccountManager.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AccountManagerDbContext accountManagerDb) : base(accountManagerDb)
        {

        }
    }
}
