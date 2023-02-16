
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace PersonalBankRepositories.Interfaces
{
    public interface ITransferRepository
    {   //TODO use inumerable?
        Task<List<TransferModel>> GetAllTransfers();
        Task<TransferModel> SearchById(int id);
        Task<TransferModel> AddTransfer(TransferModel transfer);
        Task<TransferModel> UpdateTransfer(TransferModel transfer);
        Task<bool> DeleteTransfer(int id);
    }
}
