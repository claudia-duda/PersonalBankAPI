using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Models;
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
            return await _dbContext.Deposits.AsNoTracking().SingleOrDefaultAsync(deposit => deposit.Id == id);
        }

        public async Task<DepositModel> AddDeposit(DepositModel deposit )
        {
            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();

            return deposit;
        }
        //TODO update needing a correction
        public async Task<DepositModel> UpdateDeposit(DepositModel deposit)
        {

            _dbContext.Deposits.Update(deposit);
            await _dbContext.SaveChangesAsync();
            return deposit;
   
        }
        
        public async Task<bool> DeleteDeposit(int id)
        {
            var depositFounded = await SearchById(id);
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
