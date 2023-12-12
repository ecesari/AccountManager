using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public Task Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            //var account = accountRepository.GetByIdAsync(command.AccountId) ?? throw new EntityNotFoundException(nameof(Account), command.AccountId); ;
            //var repository = new Domain.Entities.BankTransaction { Account = account}
            throw new NotImplementedException();
        }
    }
}