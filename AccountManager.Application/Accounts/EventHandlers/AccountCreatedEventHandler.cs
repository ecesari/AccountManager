using AccountManager.Application.Accounts.Commands.CreateAccount;
using AccountManager.Domain.Events;
using MediatR;

namespace AccountManager.Application.Accounts.EventHandlers;

public class AccountCreatedEventHandler : INotificationHandler<AccountCreatedEvent>
{
    private readonly IMediator mediator;

    public AccountCreatedEventHandler(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task Handle(AccountCreatedEvent notification, CancellationToken cancellationToken)
    {
        if(notification.InitialCredit != 0)
        {
            await mediator.Send(new CreateTransactionCommand { AccountId = notification.AccountId, Amount = notification.InitialCredit});
        }
    }
}
