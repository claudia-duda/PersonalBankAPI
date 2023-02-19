using AutoMapper;
using PersonalBankServices.Interfaces;
using PersonalBankRepositories.Interfaces;
using PersonalBankModels.Dtos.Account;


namespace PersonalBankServices.Repositories
{
    public class AccountService : IAccountService
    {
        //TODO implement try catch
        private IAccountRepository _accountRepository;
        private IMapper _mapper;

        public AccountService(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<ReadAccountDto> GetActualBalance()
        {
            var account =  await _accountRepository.GetBalance();
            return _mapper.Map<ReadAccountDto>(account);
        }

    }
}
