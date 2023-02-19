using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Models;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankRepositories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;

        }

        public async Task<AccountModel> GetBalance()
        {
            var accountFounded  = await _dbContext.Account.AsNoTracking().FirstOrDefaultAsync();
            if(accountFounded == null)
            {
                var account = new AccountModel { ActualBalance = 0 };
                await _dbContext.Account.AddAsync(account);
                _dbContext.SaveChanges();
                return account;
            }
            return accountFounded;

        }

        public async Task<AccountModel> UpdateBalance(AccountModel account)
        {
            _dbContext.Account.Update(account);
            _dbContext.SaveChanges();
            return account;
        }


    }
}
