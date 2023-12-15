using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Events;
using AccountManager.Domain.Repository;
using MediatR;

namespace AccountManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository repository;
        private readonly IAccountRepository accountRepository;
        private readonly IMediator mediator;

        public CreateTransactionCommandHandler(ITransactionRepository repository, IAccountRepository accountRepository, IMediator mediator)
        {
            this.repository = repository;
            this.accountRepository = accountRepository;
            this.mediator = mediator;
        }

        public async Task<Guid> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var account = await accountRepository.GetByIdAsync(command.AccountId) ?? throw new EntityNotFoundException(nameof(Account), command.AccountId);
            var transaction = new BankTransaction { Account = account, Amount = command.Amount, TransactionTime = DateTimeOffset.UtcNow };
            await repository.AddAsync(transaction);
            await mediator.Publish(new TransactionCreatedEvent(transaction.Id));
            return transaction.Id;

        }
    }
}