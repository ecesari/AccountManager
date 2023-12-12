using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using MediatR;

namespace AccountManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateTransactionCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly ITransactionRepository repository;
        private readonly IAccountRepository accountRepository;

        public CreateTransactionCommandHandler(ITransactionRepository repository, IAccountRepository accountRepository)
        {
            this.repository = repository;
            this.accountRepository = accountRepository;
        }

        public async Task Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var account = await accountRepository.GetByIdAsync(command.AccountId) ?? throw new EntityNotFoundException(nameof(Account), command.AccountId);
            var transaction = new BankTransaction { Account = account, Amount = command.Amount, TransactionTime = DateTimeOffset.UtcNow };
            await repository.AddAsync(transaction);
        }
    }
}