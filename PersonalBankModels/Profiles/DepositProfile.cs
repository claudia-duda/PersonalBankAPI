using AutoMapper;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace PersonalBankModels.Profiles
{
    public class DepositProfile : Profile
    {
        public DepositProfile()
        {
            CreateMap<CreateDepositDto, DepositModel>().ReverseMap();
            CreateMap<DepositModel, ReadDepositDto>();
            CreateMap<UpdateDepositDto, DepositModel>();
            CreateMap<UpdateDepositDto, ReadDepositDto>();
        }
    }
}
