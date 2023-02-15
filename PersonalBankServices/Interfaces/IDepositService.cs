using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace PersonalBankServices.Interfaces
{
    public interface IDepositService
    {
        Task<List<ReadDepositDto>> GetAllDeposits();
        Task<ReadDepositDto> SearchById(int id);
        Task<ReadDepositDto> AddDeposit(CreateDepositDto deposit);
        Task<ReadDepositDto> UpdateDeposit(UpdateDepositDto deposit);
        Task<bool> DeleteDeposit(int id);
    }
}