
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace PersonalBankRepositories.Interfaces
{
    public interface IWithdrawRepository
    {   //TODO use inumerable?
        Task<List<WithdrawModel>> GetAllWithdraws();
        Task<WithdrawModel> SearchById(int id);
        Task<WithdrawModel> AddWithdraw(WithdrawModel transfer);
        Task<WithdrawModel> UpdateWithdraw(WithdrawModel transfer);
        Task<bool> DeleteWithdraw(int id);
    }
}
