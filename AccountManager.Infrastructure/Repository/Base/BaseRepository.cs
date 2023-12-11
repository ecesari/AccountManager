using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AccountManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Infrastructure.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AccountManagerDbContext accountDb;

        public BaseRepository(AccountManagerDbContext accountDb)
        {
            this.accountDb = accountDb;
        }

        public async Task<T> AddAsync(T entity)
        {
            await accountDb.Set<T>().AddAsync(entity);
            await accountDb.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddAsync(List<T> entity)
        {
            await accountDb.AddRangeAsync(entity);
            await accountDb.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            accountDb.Set<T>().Remove(entity);
            await accountDb.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await accountDb.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await accountDb.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            accountDb.Entry(entity).State = EntityState.Modified;
            try
            {
                await accountDb.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

    }
}
