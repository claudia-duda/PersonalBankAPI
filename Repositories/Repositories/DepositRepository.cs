using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Models;
using Repositories;
using Repositories.Interfaces;


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

        public async Task<DepositModel> AddDeposit(DepositModel deposit)
        {
            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();
            return deposit;
        }
        //TODO remove id?
        public async Task<DepositModel> UpdateDeposit(DepositModel deposit, int id)
        {
            DepositModel depositFounded = await SearchById(id);
            if (depositFounded != null)
            {
                //TODO  mapper deposit
                depositFounded.Description = deposit.Description;
                depositFounded.AccountNumber = deposit.AccountNumber;
                depositFounded.Amount = deposit.Amount;

                _dbContext.Deposits.Update(depositFounded);
                await _dbContext.SaveChangesAsync();
                return depositFounded;
            }

            throw new Exception($"Deposit for id: {id}wasn't found");
        }
        
        public async Task<bool> DeleteDeposit(int id)
        {
            DepositModel depositFounded = await SearchById(id);
            if (depositFounded != null)
            {
                _dbContext.Deposits.Remove(depositFounded);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            throw new Exception($"Deposit for id: {id}wasn't found");
        }
    }
}
