using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using PersonalBankRepositories;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankRepositories.Repositories
{
    public class WithdrawRepository : IWithdrawRepository
    {
        private readonly AppDbContext _dbContext;

        public WithdrawRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<WithdrawModel>> GetAllWithdraws()
        {
            return await _dbContext.Withdraws.ToListAsync();
        }

        public async Task<WithdrawModel> SearchById(int id)
        {
            return await _dbContext.Withdraws.AsNoTracking().SingleOrDefaultAsync(withdraw => withdraw.Id == id);
        }

        public async Task<WithdrawModel> AddWithdraw(WithdrawModel Withdraw )
        {
            await _dbContext.Withdraws.AddAsync(Withdraw);
            await _dbContext.SaveChangesAsync();

            return Withdraw;
        }

        public async Task<WithdrawModel> UpdateWithdraw(WithdrawModel withdraw)
        {
            _dbContext.Withdraws.Update(withdraw);
            await _dbContext.SaveChangesAsync();
            return withdraw;
        }

        public async Task<bool> DeleteWithdraw(int id)
        {
            var withdrawDeleted = await SearchById(id);
            if (withdrawDeleted != null)
            {
                _dbContext.Withdraws.Remove(withdrawDeleted);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
