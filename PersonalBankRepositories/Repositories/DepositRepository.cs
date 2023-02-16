using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using PersonalBankRepositories;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankRepositories.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly AppDbContext _dbContext;

        public DepositRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<DepositModel>> GetAllDeposits()
        {
            return await _dbContext.Deposits.ToListAsync();
        }

        public async Task<DepositModel> SearchById(int id)
        {
            return await _dbContext.Deposits.FirstOrDefaultAsync(deposit => deposit.Id == id);
        }

        public async Task<DepositModel> AddDeposit(DepositModel deposit )
        {
            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();

            return deposit;
        }

        public async Task<DepositModel> UpdateDeposit(DepositModel deposit)
        {
            DepositModel depositFounded = await _dbContext.Deposits.FirstOrDefaultAsync(deposit => deposit.Id == deposit.Id);
            
            if (depositFounded != null)
            {

                _dbContext.Attach(deposit);
                _dbContext.Entry(deposit).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return deposit;
            }

            return null;
        }
        
        public async Task<bool> DeleteDeposit(int id)
        {
            DepositModel depositFounded = await _dbContext.Deposits.FirstOrDefaultAsync(deposit => deposit.Id == id);
            if (depositFounded != null)
            {
                _dbContext.Deposits.Remove(depositFounded);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;            
        }
    }
}
