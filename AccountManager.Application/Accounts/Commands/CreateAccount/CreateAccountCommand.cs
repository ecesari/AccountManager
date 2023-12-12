using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Events;
using AccountManager.Domain.Repository;
using MediatR;

namespace AccountManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Unit>
    {
        public Guid CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Unit>
    {
        private readonly IAccountRepository repository;
        private readonly ICustomerRepository customerRepository;
        private readonly IMediator mediator;
        public CreateAccountCommandHandler(IAccountRepository repository, ICustomerRepository customerRepository, IMediator mediator)
        {
            this.repository = repository;
            this.customerRepository = customerRepository;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetByIdAsync(request.CustomerId) ?? throw new EntityNotFoundException(nameof(Customer), request.CustomerId);
            var account = new Account(request.InitialCredit, customer);
            await repository.AddAsync(account);
            await mediator.Publish(new AccountCreatedEvent(account.Id, account.Balance));
            return Unit.Value;

        }
    }
}