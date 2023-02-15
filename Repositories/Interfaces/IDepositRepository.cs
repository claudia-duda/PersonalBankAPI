
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace Repositories.Interfaces
{
    public interface IDepositRepository
    {
        Task<List<ReadDepositDto>> GetAllDeposits();
        Task<ReadDepositDto> SearchById(int id);
        Task<ReadDepositDto> AddDeposit(CreateDepositDto deposit);
        Task<ReadDepositDto> UpdateDeposit(UpdateDepositDto deposit, int id);
        Task<bool> DeleteDeposit(int id);
    }
}
