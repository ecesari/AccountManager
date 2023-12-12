using AccountManager.Domain.Entities;
using MediatR;

namespace AccountManager.Domain.Events;

public class AccountCreatedEvent : INotification
{
    public Account Account { get; }
    public decimal InitialCredit { get; }

    public AccountCreatedEvent(Account account, decimal initialCredit)
    {
        Account = account;
        InitialCredit = initialCredit;
    }
}

