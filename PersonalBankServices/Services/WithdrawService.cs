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

        public async Task<ReadWithdrawDto> UpdateWithdraw(UpdateWithdrawDto withdrawDto)
        {
            var WithdrawFounded = await SearchById(withdrawDto.Id);

            if (WithdrawFounded != null)
            {
                var withdrawMapped = _mapper.Map<WithdrawModel>(withdrawDto);

                var transferChanged = await _repository.UpdateWithdraw(withdrawMapped);

                return _mapper.Map<ReadWithdrawDto>(transferChanged);
            }

            throw new Exception($"Withdraw for id: {withdrawDto.Id} wasn't found");
        }

        public async Task<bool> DeleteWithdraw(int id)
        {
            bool withdrawDeleted = await _repository.DeleteWithdraw(id);

            if (withdrawDeleted != false)
            {
                return true;//TODO sucess message
            }

            throw new Exception($"Withdraw for id: {id} wasn't found");
        }
    }
}
