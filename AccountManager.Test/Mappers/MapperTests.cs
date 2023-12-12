using AccountManager.Application.Common.Mapper;
using AccountManager.Application.Customers.Query.GetDetailedCustomerInformation;
using AccountManager.Domain.Entities;
using AutoMapper;

namespace WeatherForecast.Tests.Mappers
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
        [InlineData("name","lastname",0,0)]
        public void Given_ForecastModel_ShouldReturn_ForecastCommand(string name, string lastName, decimal accountBalance, decimal transactionAmount)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            var customer = new Customer { Id = Guid.NewGuid(), Name = name, LastName = lastName };
            var account = new Account(accountBalance, customer);
            var transaction = new BankTransaction { Amount = transactionAmount, TransactionTime = dateTimeOffset };
            account.Transactions.Add(transaction);
            customer.Accounts.Add(account);
            var model = mapper.Map<DetailedCustomerResponse>(customer);

            Assert.NotNull(model);
            Assert.Equal(1, model.Accounts.Count);
        }


        //[Theory]
        //[InlineData(2023, 1, 31, "Tuesday, January 31, 2023", 20, "foo")]
        //public void Given_ForecastResponse_ShouldReturn_DailyForecastModel(int dateYear, int dateMonth, int dateDay, string expectedDate, int temperature, string summary)
        //{
        //    var response = new WeatherForecastResponse { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Summary = summary };
        //    var model = mapper.Map<DailyWeatherForecastModel>(response);

        //    Assert.NotNull(response);
        //    Assert.Equal(response.Temperature, model.Temperature);
        //    Assert.Equal(response.Summary, model.Description);
        //    Assert.Equal(expectedDate, model.Date);
        //}


        //[Theory]
        //[InlineData(2023, 1, 31, 20, "foo")]
        //public void Given_ForecastResponseList_ShouldReturn_DailyForecastModelList(int dateYear, int dateMonth, int dateDay, int temperature, string summary)
        //{
        //    var response1 = new WeatherForecastResponse { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Summary = summary };
        //    var response2 = new WeatherForecastResponse { Date = new DateOnly(dateYear, dateMonth, dateDay), Temperature = temperature, Summary = summary };
        //    var list = new List<WeatherForecastResponse> { response1, response2 };
        //    var model = mapper.Map<List<DailyWeatherForecastModel>>(list);

        //    Assert.NotNull(model);
        //    Assert.Equal(2, model.Count);
        //}
    }
}
