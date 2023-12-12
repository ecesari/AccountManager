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
        public Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}