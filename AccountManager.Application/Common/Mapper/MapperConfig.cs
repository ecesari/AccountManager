using AccountManager.Application.Customers.Query.GetDetailedCustomerInformation;
using AccountManager.Domain.Entities;
using AutoMapper;


namespace AccountManager.Application.Common.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<BankTransaction, TransactionModel>();
            CreateMap<Account, AccountModel>();
            CreateMap<Customer, DetailedCustomerResponse>()
             .ForMember(response => response.TotalBalance, opt => opt.MapFrom(src => src.Accounts.Sum(a => a.Balance)));
        }
    }
}
