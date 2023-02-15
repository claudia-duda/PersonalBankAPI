using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using Repositories;
using Repositories.Interfaces;


namespace PersonalBankRepositories.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;

        public DepositRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext= dbContext;
            _mapper = mapper;
        }

        public async Task<List<ReadDepositDto>> GetAllDeposits()
        {
            List<DepositModel> deposits = await _dbContext.Deposits.ToListAsync();
            return _mapper.Map<List<ReadDepositDto>>(deposits);
        }

        public async Task<ReadDepositDto> SearchById(int id)
        {
            DepositModel deposit = await _dbContext.Deposits.FirstOrDefaultAsync(deposit => deposit.Id == id);
            return _mapper.Map<ReadDepositDto>(deposit);
        }

        public async Task<ReadDepositDto> AddDeposit(CreateDepositDto depositDto)
        {
            DepositModel deposit = _mapper.Map<DepositModel>(depositDto);
            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ReadDepositDto>(deposit);
        }
        //TODO remove id?
        public async Task<ReadDepositDto> UpdateDeposit(UpdateDepositDto depositDto, int id)
        {
            DepositModel depositFounded = await _dbContext.Deposits.FirstOrDefaultAsync(deposit => deposit.Id == id);
            
            if (depositFounded != null)
            {
                _mapper.Map(depositDto, depositFounded);

                _dbContext.Deposits.Update(depositFounded);
                await _dbContext.SaveChangesAsync();
                return _mapper.Map<ReadDepositDto>(depositDto);
            }

            throw new Exception($"Deposit for id: {id}wasn't found");
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
            throw new Exception($"Deposit for id: {id} wasn't found");
        }
    }
}
