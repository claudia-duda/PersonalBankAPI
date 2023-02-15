
using PersonalBankModels.Models;

namespace Repositories.Interfaces
{
    public interface IDepositRepository
    {
        Task<List<DepositModel>> GetAllDeposits();
        Task<DepositModel> SearchById(int id);
        Task<DepositModel> AddDeposit(DepositModel deposit);
        Task<DepositModel> UpdateDeposit(DepositModel deposit, int id);
        Task<bool> DeleteDeposit(int id);
    }
}
