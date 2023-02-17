using Microsoft.AspNetCore.Mvc;
using PersonalBankModels.Dtos.Withdraw;
using PersonalBankServices.Interfaces;


namespace PersonalBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {   
        private readonly IWithdrawService _WithdrawService;

        public WithdrawController(IWithdrawService WithdrawService)
        {
            _WithdrawService = WithdrawService;
        }

        [HttpGet("GetAllWithdraws")]
        public async Task<ActionResult<List<ReadWithdrawDto>>> GetAllWithdraws()
        { 
            return Ok(await _WithdrawService.GetAllWithdraws());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadWithdrawDto>> SearchById(int id)
        {
            return Ok(await _WithdrawService.SearchById(id));
        }

        [HttpPost("CreateWithdraw")]
        public async Task<ActionResult<ReadWithdrawDto>> AddWithdraw([FromBody] CreateWithdrawDto Withdraw)
        {
            return Ok(await _WithdrawService.AddWithdraw(Withdraw));
        }
        
        [HttpPut("UpdateWithdraw")]
        public async Task<ActionResult<ReadWithdrawDto>> UpdateWithdraw([FromBody] UpdateWithdrawDto Withdraw)
        {
            return Ok(await _WithdrawService.UpdateWithdraw(Withdraw));
        }

        [HttpDelete("{id}")]    
        public async Task<ActionResult<ReadWithdrawDto>> DeleteWithdraw(int id)
        {
            return Ok(await _WithdrawService.DeleteWithdraw(id));
        }

    }
}
