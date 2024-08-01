using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _accountService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("{accountName}")]
        public async Task<IActionResult> GetAllAccountsByName(string accountName)
        {
            return Ok(await _accountService.GetAccountbyName(accountName));
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchPagedAccounts(string search, int page = 1, int pageSize = 10)
        {
            var result = await _accountService.SearchPagedAccountbyName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromForm] Request_CreateAccount request)
        {
            return Ok(await _accountService.AddAccount(request));
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount(int accountId, [FromBody] Request_UpdateAccount request)
        {
            return Ok(await _accountService.UpdateAccount(accountId, request));
        }

        [HttpDelete("{accountId}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int accountId)
        {
            return Ok(await _accountService.Delete(accountId));
        }

    }
}
