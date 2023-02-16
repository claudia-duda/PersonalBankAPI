using AutoMapper;
using PersonalBankModels.Dtos.Withdraw;
using PersonalBankModels.Models;

namespace PersonalBankModels.Profiles
{
    public class WithdrawProfile : Profile
    {
        public WithdrawProfile()
        {
            CreateMap<CreateWithdrawDto, WithdrawModel>().ReverseMap();
            CreateMap<WithdrawModel, ReadWithdrawDto>();
            CreateMap<UpdateWithdrawDto, WithdrawModel>();
            CreateMap<UpdateWithdrawDto, ReadWithdrawDto>();
        }
    }
}
