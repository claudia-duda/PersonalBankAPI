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
            return await _dbContext.Withdraws.FirstOrDefaultAsync(withdraw => withdraw.Id == id);
        }

        public async Task<WithdrawModel> AddWithdraw(WithdrawModel Withdraw )
        {
            await _dbContext.Withdraws.AddAsync(Withdraw);
            await _dbContext.SaveChangesAsync();

            return Withdraw;
        }

        public async Task<WithdrawModel> UpdateWithdraw(WithdrawModel withdraw)
        {
            WithdrawModel depositFounded = await _dbContext.Withdraws.FirstOrDefaultAsync(Withdraw => Withdraw.Id == Withdraw.Id);
            
            if (depositFounded != null)
            {

                _dbContext.Attach(withdraw);
                _dbContext.Entry(withdraw).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return withdraw;
            }

            return null;
        }
        
        public async Task<bool> DeleteWithdraw(int id)
        {
            WithdrawModel withdrawFounded = await _dbContext.Withdraws.FirstOrDefaultAsync(Withdraw => Withdraw.Id == id);
            if (withdrawFounded != null)
            {
                _dbContext.Withdraws.Remove(withdrawFounded);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;            
        }
    }
}
