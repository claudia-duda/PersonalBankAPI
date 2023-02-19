using AutoMapper;
using PersonalBankModels.Dtos.Transfer;
using PersonalBankModels.Models;
using PersonalBankServices.Interfaces;
using PersonalBankRepositories.Interfaces;


namespace PersonalBankServices.Repositories
{
    public class TransferService : ITransferService
    {
        //TODO implement try catch
        private ITransferRepository _repository;
        private IAccountRepository _accountRepository;
        private IMapper _mapper;

        public TransferService(ITransferRepository repository, IMapper mapper, IAccountRepository accountRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<List<ReadTransferDto>> GetAllTransfers()
        {

            List<TransferModel> Transfers = await _repository.GetAllTransfers();
            return _mapper.Map<List<ReadTransferDto>>(Transfers);

        }

        public async Task<ReadTransferDto> SearchById(int id)
        {
            TransferModel transfer = await _repository.SearchById(id);
            return _mapper.Map<ReadTransferDto>(transfer);
        }

        public async Task<ReadTransferDto> AddTransfer(CreateTransferDto transferDto)
        {
            AccountModel balance = await _accountRepository.GetBalance();
            if (transferDto.Amount > 0 && balance.ActualBalance > transferDto.Amount)
            {
                TransferModel transfer = _mapper.Map<TransferModel>(transferDto);
                balance.ActualBalance -= transfer.Amount;
                if (balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }
                await _accountRepository.UpdateBalance(balance);
                await _repository.AddTransfer(transfer);

                return _mapper.Map<ReadTransferDto>(transfer);
            }
            throw new Exception($"Transfer wasn't suceeded");
        }

        public async Task<ReadTransferDto> UpdateTransfer(UpdateTransferDto transferDto)
        {
            var transferFounded = await SearchById(transferDto.Id);

            if (transferFounded != null)
            {
                var balance = await _accountRepository.GetBalance();
                balance.ActualBalance += transferFounded.Amount;

                var transferMapped = _mapper.Map<TransferModel>(transferDto);
                balance.ActualBalance -= transferMapped.Amount;
                if (balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }

                await _accountRepository.UpdateBalance(balance);

                var transferChanged = await _repository.UpdateTransfer(transferMapped);
                return _mapper.Map<ReadTransferDto>(transferChanged);
     
            }

            throw new Exception($"Transfer wasn't suceeded");
        }

        public async Task<bool> DeleteTransfer(int id)
        {
            var transferFounded = await SearchById(id);

            if (transferFounded != null)
            {
                var balance = await _accountRepository.GetBalance();
                balance.ActualBalance += transferFounded.Amount;
                if (balance.ActualBalance < 0)
                {
                    balance.ActualBalance = 0;
                }
                await _accountRepository.UpdateBalance(balance);
                return await _repository.DeleteTransfer(id);
            }

            throw new Exception($"Transfer for id: {id} wasn't found");
        }
    }
}
