using PersonalBankModels.Dtos.Withdraw;

namespace PersonalBankServices.Interfaces
{
    public interface IWithdrawService
    {
        Task<List<ReadWithdrawDto>> GetAllWithdraws();
        Task<ReadWithdrawDto> SearchById(int id);
        Task<ReadWithdrawDto> AddWithdraw(CreateWithdrawDto Withdraw);
        Task<ReadWithdrawDto> UpdateWithdraw(UpdateWithdrawDto Withdraw);
        Task<bool> DeleteWithdraw(int id);
    }
}