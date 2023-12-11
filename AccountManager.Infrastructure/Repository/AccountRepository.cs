using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AccountManager.Infrastructure.Data;
using AccountManager.Infrastructure.Repository.Base;

namespace AccountManager.Infrastructure.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AccountManagerDbContext accountManagerDb) : base(accountManagerDb)
        {

        }
    }
}
