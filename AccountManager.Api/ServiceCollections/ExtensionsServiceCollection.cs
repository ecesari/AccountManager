using AccountManager.Application.Common.Mapper;
using AccountManager.Domain.Repository;
using AccountManager.Infrastructure.Repository;
using AccountManager.Infrastructure.Repository.Base;
using AutoMapper;

namespace AccountManager.Api.ServiceCollections
{

    public static class ExtensionsServiceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());

            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }


    }

}
