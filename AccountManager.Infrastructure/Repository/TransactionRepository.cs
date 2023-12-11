using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AccountManager.Infrastructure.Data;
using AccountManager.Infrastructure.Repository.Base;

namespace AccountManager.Infrastructure.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AccountManagerDbContext accountManagerDb) : base(accountManagerDb)
        {

        }
    }
}
