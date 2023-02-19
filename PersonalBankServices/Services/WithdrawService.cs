using AutoMapper;
using PersonalBankModels.Dtos.Withdraw;
using PersonalBankModels.Models;
using PersonalBankServices.Interfaces;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankServices.Repositories
{
    public class WithdrawService : IWithdrawService
    {
        //TODO implement try catch
        private IWithdrawRepository _repository;
        private IMapper _mapper;
        private IAccountRepository _accountRepository;

        public WithdrawService(IWithdrawRepository repository, IMapper mapper, IAccountRepository accountRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<List<ReadWithdrawDto>> GetAllWithdraws()
        {

            List<WithdrawModel> Withdraws = await _repository.GetAllWithdraws();
            return _mapper.Map<List<ReadWithdrawDto>>(Withdraws);

        }

        public async Task<ReadWithdrawDto> SearchById(int id)
        {
            WithdrawModel Withdraw = await _repository.SearchById(id);
            return _mapper.Map<ReadWithdrawDto>(Withdraw);
        }

        public async Task<ReadWithdrawDto> AddWithdraw(CreateWithdrawDto WithdrawDto)
        {
            AccountModel balance = await _accountRepository.GetBalance();
            if (WithdrawDto.Amount > 0 && balance.ActualBalance > WithdrawDto.Amount)
            {
                var withdraw = _mapper.Map<WithdrawModel>(WithdrawDto);
                balance.ActualBalance -= withdraw.Amount;
                if (balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }

                await _accountRepository.UpdateBalance(balance);
                await _repository.AddWithdraw(withdraw);

                return _mapper.Map<ReadWithdrawDto>(withdraw);

            }

            throw new Exception($"Withdraw wasn't suceeded");

        }

        public async Task<ReadWithdrawDto> UpdateWithdraw(UpdateWithdrawDto withdrawDto)
        {
            var WithdrawFounded = await SearchById(withdrawDto.Id);

            if (WithdrawFounded != null)
            {
                AccountModel balance = await _accountRepository.GetBalance();
                balance.ActualBalance += WithdrawFounded.Amount;

                var depositMapped = _mapper.Map<WithdrawModel>(withdrawDto);
                balance.ActualBalance -= depositMapped.Amount;
                if (balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }
                await _accountRepository.UpdateBalance(balance);

                var withDrawChanged = await _repository.UpdateWithdraw(depositMapped);
                return _mapper.Map<ReadWithdrawDto>(withDrawChanged);
            }

            throw new Exception($"Withdraw for id: {withdrawDto.Id} wasn't found");
        }

        public async Task<bool> DeleteWithdraw(int id)
        {
            var withdrawToDelete = await SearchById(id);

            if (withdrawToDelete != null)
            {
                var balance = await _accountRepository.GetBalance();
                balance.ActualBalance += withdrawToDelete.Amount;
                await _accountRepository.UpdateBalance(balance);
                if (balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }
                return await _repository.DeleteWithdraw(id);
            }

            throw new Exception($"Withdraw for id: {id} wasn't found");
        }
    }
}
