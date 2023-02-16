using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using PersonalBankRepositories;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankRepositories.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly AppDbContext _dbContext;

        public TransferRepository(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<TransferModel>> GetAllTransfers()
        {
            return await _dbContext.Transfers.ToListAsync();
        }

        public async Task<TransferModel> SearchById(int id)
        {
            return await _dbContext.Transfers.AsNoTracking().SingleOrDefaultAsync(transfer => transfer.Id == id);
        }

        public async Task<TransferModel> AddTransfer(TransferModel transfer )
        {
            await _dbContext.Transfers.AddAsync(transfer);
            await _dbContext.SaveChangesAsync();

            return transfer;
        }

        public async Task<TransferModel> UpdateTransfer(TransferModel transfer)
        {

            _dbContext.Transfers.Update(transfer);
            await _dbContext.SaveChangesAsync();
            return transfer;
        }
        
        public async Task<bool> DeleteTransfer(int id)
        {
            TransferModel transferFounded = await _dbContext.Transfers.FirstOrDefaultAsync(transfer => transfer.Id == id);
            if (transferFounded != null)
            {
                _dbContext.Transfers.Remove(transferFounded);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;            
        }
    }
}
