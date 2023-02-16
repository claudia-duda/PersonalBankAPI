using PersonalBankModels.Dtos.Transfer;

namespace PersonalBankServices.Interfaces
{
    public interface ITransferService
    {
        Task<List<ReadTransferDto>> GetAllTransfers();
        Task<ReadTransferDto> SearchById(int id);
        Task<ReadTransferDto> AddTransfer(CreateTransferDto Transfer);
        Task<ReadTransferDto> UpdateTransfer(UpdateTransferDto Transfer);
        Task<bool> DeleteTransfer(int id);
    }
}