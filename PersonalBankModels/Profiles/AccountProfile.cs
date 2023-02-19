using AutoMapper;
using PersonalBankModels.Dtos.Account;
using PersonalBankModels.Models;

namespace PersonalBankModels.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<ReadAccountDto, AccountModel>().ReverseMap();

        }
    }
}
