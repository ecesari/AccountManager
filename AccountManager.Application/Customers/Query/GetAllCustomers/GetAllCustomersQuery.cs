using AccountManager.Domain.Repository;
using AutoMapper;
using MediatR;

namespace AccountManager.Application.Customers.Query.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<CustomerInformationResponse>
    {
    }

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, CustomerInformationResponse>
    {
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CustomerInformationResponse> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await repository.GetAllAsync();
            var response = mapper.Map<CustomerInformationResponse>(customers);
            return response;
        }
    }
}
