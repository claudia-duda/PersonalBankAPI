using AutoMapper;
using PersonalBankModels.Dtos.Transfer;
using PersonalBankModels.Models;

namespace PersonalBankModels.Profiles
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {
            CreateMap<CreateTransferDto, TransferModel>().ReverseMap();
            CreateMap<TransferModel, ReadTransferDto>();
            CreateMap<UpdateTransferDto, TransferModel>();
            CreateMap<UpdateTransferDto, ReadTransferDto>();
        }
    }
}
