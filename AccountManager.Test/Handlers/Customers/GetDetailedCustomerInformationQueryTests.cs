using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Customers.Query.GetDetailedCustomerInformation;
using AccountManager.Domain.Entities;
using AccountManager.Domain.Repository;
using AutoMapper;
using Moq;

namespace AccountManager.Test.Handlers.Customers
{
    public class GetDetailedCustomerInformationQueryTests
    {
        private readonly Mock<ICustomerRepository> repositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly GetDetailedCustomerInformationQueryHandler handler;

        public GetDetailedCustomerInformationQueryTests()
        {
            repositoryMock = new Mock<ICustomerRepository>();
            mapperMock = new Mock<IMapper>();
            handler = new GetDetailedCustomerInformationQueryHandler(repositoryMock.Object, mapperMock.Object);
        }

        [Fact]
        public void ConfigurationTest()
        {
            Assert.NotNull(handler);
        }

        [Fact]
        public void Given_CustomerNotFound_Should_ThrowError()
        {
            var command = new GetDetailedCustomerInformationQuery { CustomerId = Guid.NewGuid() };
            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns<Customer?>(null);
            Assert.ThrowsAsync<EntityNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
