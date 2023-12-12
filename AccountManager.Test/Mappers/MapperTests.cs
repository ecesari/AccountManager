using AccountManager.Application.Accounts.Models;
using AccountManager.Application.Common.Mapper;
using AccountManager.Application.Customers.Query.GetDetailedCustomerInformation;
using AccountManager.Application.Transactions.Models;
using AccountManager.Domain.Entities;
using AutoMapper;

namespace AccountManager.Test.Mappers
{
    public class MapperTests
    {
        private readonly IMapper mapper;
        private readonly MapperConfiguration config;


        public MapperTests()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfig());
            }); mapper = config.CreateMapper();
        }

        [Fact]
        public void ConfigurationTest()
        {
            config.AssertConfigurationIsValid();

            Assert.NotNull(mapper);
        }

        [Theory]
        [InlineData(100.5)]
        public void Given_BankTransaction_ShouldReturn_TransactionModel(decimal transactionAmount)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            var transaction = new BankTransaction { Amount = transactionAmount, TransactionTime = dateTimeOffset };
            var model = mapper.Map<TransactionModel>(transaction);

            Assert.NotNull(model);
            Assert.Equal(transactionAmount, model.Amount);
            Assert.Equal(dateTimeOffset, model.TransactionTime);
        }

        [Theory]
        [InlineData(100, 30)]
        public void Given_Account_ShouldReturn_AccountModel(decimal accountBalance, decimal transactionAmount)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            var account = new Account(accountBalance, new Customer());
            var transaction = new BankTransaction { Amount = transactionAmount, TransactionTime = dateTimeOffset };
            account.Transactions.Add(transaction);
            var model = mapper.Map<AccountModel>(account);

            Assert.NotNull(model);
            Assert.Equal(accountBalance, model.Balance);
            Assert.Single(model.Transactions);
            Assert.Equal(transactionAmount, model.Transactions.FirstOrDefault().Amount);
        }



        [Theory]
        [InlineData("name", "lastname", 0, 0)]
        public void Given_Customer_ShouldReturn_CustomerModel(string name, string lastName, decimal accountBalance, decimal transactionAmount)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            var customer = new Customer { Id = Guid.NewGuid(), Name = name, LastName = lastName };
            var account = new Account(accountBalance, customer);
            var transaction = new BankTransaction { Amount = transactionAmount, TransactionTime = dateTimeOffset };
            account.Transactions.Add(transaction);
            customer.Accounts = new List<Account> { account };
            var model = mapper.Map<DetailedCustomerResponse>(customer);

            Assert.NotNull(model);
            Assert.Single(model.Accounts);
            Assert.Equal(accountBalance, model.Accounts.FirstOrDefault().Balance);
            Assert.Equal(transactionAmount, model.Accounts.FirstOrDefault().Transactions.FirstOrDefault().Amount);
            Assert.Equal(dateTimeOffset, model.Accounts.FirstOrDefault().Transactions.FirstOrDefault().TransactionTime);

        }
    }
}
