using AccountManager.Domain.Entities;

namespace AccountManager.Domain.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetByIdWithDetailedInformation(Guid id);
        Task<IReadOnlyList<Customer>> GetAllWithDetailedInformation();
    }
}
