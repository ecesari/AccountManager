using MediatR;

namespace AccountManager.Domain.Events;

public class CustomerCreatedEvent : INotification
{
    public Guid CustomerId { get; }

    public CustomerCreatedEvent(Guid customerId)
    {
        CustomerId = customerId;
    }
}