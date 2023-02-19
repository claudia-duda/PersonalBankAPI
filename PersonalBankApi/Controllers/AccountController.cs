using Microsoft.AspNetCore.Mvc;
using PersonalBankModels.Dtos.Account;
using PersonalBankServices.Interfaces;


namespace PersonalBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("GetActualBalance")]
        public async Task<ActionResult<ReadAccountDto>> GetBalance()
        { 
            return Ok(await _accountService.GetActualBalance());
        }


    }
}
