using PersonalBankModels.Dtos.Account;

namespace PersonalBankServices.Interfaces
{
    public interface IAccountService
    {
        Task<ReadAccountDto> GetActualBalance();
    }
}