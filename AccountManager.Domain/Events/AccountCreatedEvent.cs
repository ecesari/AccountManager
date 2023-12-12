using AccountManager.Domain.Entities;
using MediatR;

namespace AccountManager.Domain.Events;

public class AccountCreatedEvent : INotification
{
    public Guid AccountId { get; }
    public decimal InitialCredit { get; set; }

    public AccountCreatedEvent(Guid accountId, decimal initialCredit)
    {
        AccountId = accountId;
        InitialCredit = initialCredit;
    }
}

