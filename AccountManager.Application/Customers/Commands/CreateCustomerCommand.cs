using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Events;
using AccountManager.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            this.repository = repository;
        }



        public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer { Name = command.Name, LastName = command.LastName};            
            await repository.AddAsync(customer);
            return customer.Id;
        }
    }
}
