using MediatR;

namespace AccountManager.Domain.Events;

public class TransactionCreatedEvent : INotification
{
    public Guid TransactionId { get; }

    public TransactionCreatedEvent(Guid transactionId)
    {
        TransactionId = transactionId;
    }
}