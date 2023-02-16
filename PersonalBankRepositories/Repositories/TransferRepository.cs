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
            return await _dbContext.Transfers.FirstOrDefaultAsync(transfer => transfer.Id == id);
        }

        public async Task<TransferModel> AddTransfer(TransferModel transfer )
        {
            await _dbContext.Transfers.AddAsync(transfer);
            await _dbContext.SaveChangesAsync();

            return transfer;
        }

        public async Task<TransferModel> UpdateTransfer(TransferModel transfer)
        {
            TransferModel depositFounded = await _dbContext.Transfers.FirstOrDefaultAsync(transfer => transfer.Id == transfer.Id);
            
            if (depositFounded != null)
            {

                _dbContext.Attach(transfer);
                _dbContext.Entry(transfer).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return transfer;
            }

            return null;
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
