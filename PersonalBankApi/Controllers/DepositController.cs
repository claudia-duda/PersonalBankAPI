using Microsoft.AspNetCore.Mvc;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankServices.Interfaces;


namespace PersonalBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {   
        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpGet("GetAllDeposits")]
        public async Task<ActionResult<List<ReadDepositDto>>> GetAllDeposits()
        { 
            return Ok(await _depositService.GetAllDeposits());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDepositDto>> SearchById(int id)
        {
            return Ok(await _depositService.SearchById(id));
        }

        [HttpPost("CreateDeposit")]
        public async Task<ActionResult<ReadDepositDto>> AddDeposit([FromBody] CreateDepositDto deposit)
        {
            return Ok(await _depositService.AddDeposit(deposit));
        }
        
        [HttpPut("UpdateDeposit")]
        public async Task<ActionResult<ReadDepositDto>> UpdateDeposit([FromBody] UpdateDepositDto deposit)
        {
            return Ok(await _depositService.UpdateDeposit(deposit));
        }

        [HttpDelete("{id}")]    
        public async Task<ActionResult<bool>> DeleteDeposit(int id)
        {
            return Ok(await _depositService.DeleteDeposit(id));
        }

    }
}
