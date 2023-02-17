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
        private IMapper _mapper;

        public DepositService(IDepositRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            var deposit = _mapper.Map<DepositModel>(depositDto);
            await _repository.AddDeposit(deposit);

            return _mapper.Map<ReadDepositDto>(deposit);
        }

        public async Task<ReadDepositDto> UpdateDeposit(UpdateDepositDto depositDto)
        {

            var depositFounded = await SearchById(depositDto.Id);

            if (depositFounded != null)
            {
                var depositMapped = _mapper.Map<DepositModel>(depositDto);
    
                var depositChanged = await _repository.UpdateDeposit(depositMapped);

                return _mapper.Map<ReadDepositDto>(depositChanged);
            }

            throw new Exception($"Deposit for id: {depositDto.Id} wasn't found");
        }

        public async Task<bool> DeleteDeposit(int id)
        {
            bool depositDeleted = await _repository.DeleteDeposit(id);

            if (depositDeleted != false)
            {
                return true;//TODO sucess message
            }

            throw new Exception($"Deposit for id: {id} wasn't found");
        }
    }
}
