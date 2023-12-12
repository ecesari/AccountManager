using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AutoMapper;
using MediatR;

namespace AccountManager.Application.Customers.Query.GetDetailedCustomerInformation
{
    public class GetDetailedCustomerInformationQuery : IRequest<DetailedCustomerResponse>
    {
        public Guid CustomerId { get; set; }
    }

    public class GetDetailedCustomerInformationQueryHandler : IRequestHandler<GetDetailedCustomerInformationQuery, DetailedCustomerResponse>
    {
        private readonly ICustomerRepository repository;
        private readonly IMapper mapper;

        public GetDetailedCustomerInformationQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DetailedCustomerResponse> Handle(GetDetailedCustomerInformationQuery request, CancellationToken cancellationToken)
        {
            var customer = await repository.GetByIdAsync(request.CustomerId) ?? throw new EntityNotFoundException(nameof(Customer), request.CustomerId);
            var response = mapper.Map<DetailedCustomerResponse>(customer);
            return response;    
        }
    }
}
