using Microsoft.AspNetCore.Mvc;
using PersonalBankModels.Dtos.Transfer;
using PersonalBankServices.Interfaces;


namespace PersonalBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {   
        private readonly ITransferService _TransferService;

        public TransferController(ITransferService TransferService)
        {
            _TransferService = TransferService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadTransferDto>>> GetAllTransfers()
        { 
            return Ok(await _TransferService.GetAllTransfers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadTransferDto>> SearchById(int id)
        {
            return Ok(await _TransferService.SearchById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ReadTransferDto>> AddTransfer([FromBody] CreateTransferDto transfer)
        {
            return Ok(await _TransferService.AddTransfer(transfer));
        }
        
        [HttpPut]
        public async Task<ActionResult<ReadTransferDto>> UpdateTransfer([FromBody] UpdateTransferDto transfer)
        {
            return Ok(await _TransferService.UpdateTransfer(transfer));
        }

        [HttpDelete("{id}")]    
        public async Task<ActionResult<ReadTransferDto>> DeleteTransfer(int id)
        {
            return Ok(await _TransferService.DeleteTransfer(id));
        }

    }
}
