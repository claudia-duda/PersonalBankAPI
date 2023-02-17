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
        private IMapper _mapper;

        public TransferService(ITransferRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            TransferModel transfer = _mapper.Map<TransferModel>(transferDto);
            await _repository.AddTransfer(transfer);

            return _mapper.Map<ReadTransferDto>(transfer);
        }

        public async Task<ReadTransferDto> UpdateTransfer(UpdateTransferDto transferDto)
        {
            var transferFounded = await SearchById(transferDto.Id);

            if (transferFounded != null)
            {
                var transferMapped = _mapper.Map<TransferModel>(transferDto);

                var transferChanged = await _repository.UpdateTransfer(transferMapped);

                return _mapper.Map<ReadTransferDto>(transferChanged);
            }

            throw new Exception($"Transfer for id: {transferDto.Id} wasn't found");
        }

        public async Task<bool> DeleteTransfer(int id)
        {
            bool transferDeleted = await _repository.DeleteTransfer(id);

            if (transferDeleted != false)
            {
                return true;//TODO sucess message
            }

            throw new Exception($"Transfer for id: {id} wasn't found");
        }
    }
}
