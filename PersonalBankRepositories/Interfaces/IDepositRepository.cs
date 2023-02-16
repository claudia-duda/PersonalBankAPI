
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace PersonalBankRepositories.Interfaces
{
    public interface IDepositRepository
    {   //TODO use inumerable?
        Task<List<DepositModel>> GetAllDeposits();
        Task<DepositModel> SearchById(int id);
        Task<DepositModel> AddDeposit(DepositModel deposit);
        Task<DepositModel> UpdateDeposit(DepositModel deposit);
        Task<bool> DeleteDeposit(int id);
    }
}
