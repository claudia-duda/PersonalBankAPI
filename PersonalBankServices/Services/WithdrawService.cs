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

        public WithdrawService(IWithdrawRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            WithdrawModel Withdraw = _mapper.Map<WithdrawModel>(WithdrawDto);
            await _repository.AddWithdraw(Withdraw);

            return _mapper.Map<ReadWithdrawDto>(Withdraw);
        }

        public async Task<ReadWithdrawDto> UpdateWithdraw(UpdateWithdrawDto WithdrawDto)
        {       


            WithdrawModel WithdrawChanged = await _repository.UpdateWithdraw(
                    _mapper.Map<WithdrawModel>(WithdrawDto));

            if (WithdrawChanged != null)
            {                
                return _mapper.Map<ReadWithdrawDto>(WithdrawDto);
            }

            throw new Exception($"Withdraw for id: {WithdrawDto.Id} wasn't found");
        }
        
        public async Task<bool> DeleteWithdraw(int id)
        {
            bool WithdrawDeleted = await _repository.DeleteWithdraw(id);
            if (WithdrawDeleted != false)
            {
                return true;//TODO sucess message
            }

            throw new Exception($"Withdraw for id: {id} wasn't found");
        }
    }
}
