
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;

namespace PersonalBankRepositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountModel> UpdateBalance(AccountModel account);
        Task<AccountModel> GetBalance();
    }
}
