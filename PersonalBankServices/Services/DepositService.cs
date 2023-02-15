using AutoMapper;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using PersonalBankServices.Interfaces;
using Repositories.Interfaces;


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
            List<DepositModel> deposits = await _repository.GetAllDeposits();
            return _mapper.Map<List<ReadDepositDto>>(deposits);
        }

        public async Task<ReadDepositDto> SearchById(int id)
        {
            DepositModel deposit = await _repository.SearchById(id);
            return _mapper.Map<ReadDepositDto>(deposit);
        }

        public async Task<ReadDepositDto> AddDeposit(CreateDepositDto depositDto)
        {
            DepositModel deposit = _mapper.Map<DepositModel>(depositDto);
            await _repository.AddDeposit(deposit);

            return _mapper.Map<ReadDepositDto>(deposit);
        }

        public async Task<ReadDepositDto> UpdateDeposit(UpdateDepositDto depositDto)
        {       


            DepositModel depositChanged = await _repository.UpdateDeposit(
                    _mapper.Map<DepositModel>(depositDto));

            if (depositChanged != null)
            {                
                return _mapper.Map<ReadDepositDto>(depositDto);
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
