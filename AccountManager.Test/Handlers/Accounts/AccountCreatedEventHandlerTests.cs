using AccountManager.Application.Accounts.EventHandlers;
using MediatR;
using Moq;

namespace AccountManager.Test.Handlers.Accounts
{
    public class AccountCreatedEventHandlerTests
    {
        private readonly AccountCreatedEventHandler handler;
        private readonly Mock<IMediator> mediator;

        public AccountCreatedEventHandlerTests()
        {
            mediator = new Mock<IMediator>();
            handler = new AccountCreatedEventHandler(mediator.Object);
        }

        [Fact]
        public void ConfigurationTest()
        {
            Assert.NotNull(handler);
        }       
    }
}