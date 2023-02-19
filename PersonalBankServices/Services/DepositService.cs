using AutoMapper;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using PersonalBankServices.Interfaces;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankServices.Repositories
{
    public class DepositService : IDepositService
    {
        //TODO implement try catch
        private IDepositRepository _repository;
        private IAccountRepository _accountRepository;
        private IMapper _mapper;

        public DepositService(IDepositRepository repository, IMapper mapper, IAccountRepository accountRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<List<ReadDepositDto>> GetAllDeposits()
        {

            var deposits = await _repository.GetAllDeposits();
            return _mapper.Map<List<ReadDepositDto>>(deposits);

        }

        public async Task<ReadDepositDto> SearchById(int id)
        {
            var deposit = await _repository.SearchById(id);
            return _mapper.Map<ReadDepositDto>(deposit);
        }

        public async Task<ReadDepositDto> AddDeposit(CreateDepositDto depositDto)
        {
            if(depositDto.Amount > 0)
            {
                var deposit = _mapper.Map<DepositModel>(depositDto);
                await _repository.AddDeposit(deposit);

                AccountModel balance = await _accountRepository.GetBalance();
                balance.ActualBalance += deposit.Amount;
                await _accountRepository.UpdateBalance(balance);

                return _mapper.Map<ReadDepositDto>(deposit);
            }
                throw new Exception("Amount value isn't valid to deposit in your account");
        }


        public async Task<ReadDepositDto> UpdateDeposit(UpdateDepositDto depositDto)
        {

            var depositFounded = await SearchById(depositDto.Id);

            if (depositFounded != null)
            {
                AccountModel balance = await _accountRepository.GetBalance();
                balance.ActualBalance -= depositFounded.Amount;

                var depositMapped = _mapper.Map<DepositModel>(depositDto);
                balance.ActualBalance += depositMapped.Amount;
                await _accountRepository.UpdateBalance(balance);

                var depositChanged = await _repository.UpdateDeposit(depositMapped);
                return _mapper.Map<ReadDepositDto>(depositChanged);
            }

            throw new Exception($"Deposit for id: {depositDto.Id} wasn't found");
        }

        public async Task<bool> DeleteDeposit(int id)
        {
            var depositDeleted = await SearchById(id);

            if (depositDeleted != null)
            {
                AccountModel balance = await _accountRepository.GetBalance();
                balance.ActualBalance -= depositDeleted.Amount;
                if(balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }
                await _accountRepository.UpdateBalance(balance);

                return await _repository.DeleteDeposit(id);
            }

            throw new Exception($"Deposit for id: {id} wasn't found");
        }
    }
}
