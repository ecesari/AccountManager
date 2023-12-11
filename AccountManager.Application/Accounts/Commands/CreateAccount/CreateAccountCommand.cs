using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using MediatR;

namespace AccountManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IAccountRepository repository;
        private readonly ICustomerRepository customerRepository;
        public CreateAccountCommandHandler(IAccountRepository repository, ICustomerRepository customerRepository)
        {
            this.repository = repository;
            this.customerRepository = customerRepository;
        }

        public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetByIdAsync(request.CustomerId) ?? throw new EntityNotFoundException(nameof(Customer), request.CustomerId);
            var account = new Account(request.InitialCredit, customer);
            await repository.AddAsync(account);
        }
    }
}