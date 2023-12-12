using AccountManager.Application.Accounts.Commands.CreateAccount;
using AccountManager.Application.Common.Exceptions;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using MediatR;
using Moq;

namespace iPractice.Test.Handlers.Clients
{
    public class CreateAccountCommandTests
    {
        private readonly Mock<IAccountRepository> repositoryMock;
        private readonly Mock<ICustomerRepository> customerRepositoryMock;
        private readonly Mock<IMediator> mediatorMock;
        private readonly CreateAccountCommandHandler handler;

        public CreateAccountCommandTests()
        {
            repositoryMock = new Mock<IAccountRepository>();
            customerRepositoryMock = new Mock<ICustomerRepository>();
            mediatorMock = new Mock<IMediator>();
            handler = new CreateAccountCommandHandler(repositoryMock.Object, customerRepositoryMock.Object, mediatorMock.Object);
        }

        [Fact]
        public void ConfigurationTest()
        {
            Assert.NotNull(handler);
        }

        [Fact]
        public void Given_CustomerNotFound_Should_ThrowError()
        {
            var command = new CreateAccountCommand { CustomerId = Guid.NewGuid(), InitialCredit = 0 };
            customerRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Customer?>(null);
            Assert.ThrowsAsync<EntityNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }        
    }
}
