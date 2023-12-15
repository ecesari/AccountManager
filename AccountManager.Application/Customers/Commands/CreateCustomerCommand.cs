using AccountManager.Domain.Entities;
using AccountManager.Domain.Events;
using AccountManager.Domain.Repository;
using MediatR;

namespace AccountManager.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository repository;
        private readonly IMediator mediator;

        public CreateCustomerCommandHandler(ICustomerRepository repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer { Name = command.Name, LastName = command.LastName};            
            await repository.AddAsync(customer);
            await mediator.Publish(new CustomerCreatedEvent(customer.Id));
            return customer.Id;
        }
    }
}
