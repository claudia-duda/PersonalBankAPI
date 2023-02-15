using Microsoft.AspNetCore.Mvc;
using PersonalBankModels.Dtos.Deposit;
using PersonalBankModels.Models;
using Repositories.Interfaces;

namespace PersonalBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {   
        //TODO transform repository like a service?
        private readonly IDepositRepository _depositRepository;

        public DepositController(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadDepositDto>>> GetAllDeposits()
        { 
            return Ok(await _depositRepository.GetAllDeposits());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDepositDto>> SearchById(int id)
        {
            return Ok(await _depositRepository.SearchById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ReadDepositDto>> AddDeposit([FromBody] CreateDepositDto deposit)
        {
            return Ok(await _depositRepository.AddDeposit(deposit));
        }
        
        [HttpPut]
        public async Task<ActionResult<ReadDepositDto>> UpdateDeposit([FromBody] UpdateDepositDto deposit)
        {
            return Ok(await _depositRepository.UpdateDeposit(deposit));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadDepositDto>> DeleteDeposit(int id)
        {
            return Ok(await _depositRepository.DeleteDeposit(id));
        }

    }
}
