using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<DepositModel>>> GetAllDeposits()
        { 
            return Ok(await _depositRepository.GetAllDeposits());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepositModel>> SearchById(int id)
        {
            return Ok(await _depositRepository.SearchById(id));
        }

        [HttpPost]
        public async Task<ActionResult<DepositModel>> AddDeposit([FromBody] DepositModel deposit)
        {
            return Ok(await _depositRepository.AddDeposit(deposit));
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<DepositModel>> UpdateDeposit([FromBody] DepositModel deposit, int id)
        {
            return Ok(await _depositRepository.AddDeposit(deposit));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DepositModel>> DeleteDeposit(int id)
        {
            return Ok(await _depositRepository.DeleteDeposit(id));
        }

    }
}
