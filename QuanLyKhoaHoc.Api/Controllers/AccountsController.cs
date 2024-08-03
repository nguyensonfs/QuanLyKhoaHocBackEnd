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
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _accountService.GetAlls(pageSize, pageNumber));
        }

        // GET: api/accounts/byname/{accountName}
        [HttpGet("byname/{accountName}")]
        public async Task<IActionResult> GetAccountByName(string accountName)
        {
            return Ok(await _accountService.GetAccountbyName(accountName));
        }


        // GET: api/accounts/search
        [HttpGet("search")]
        public async Task<IActionResult> SearchPagedAccounts(string search, int page = 1, int pageSize = 10)
        {
            var result = await _accountService.SearchPagedAccountbyName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create( Request_CreateAccount request)
        {
            return Ok(await _accountService.CreateAccount(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,  Request_UpdateAccount request)
        {
            return Ok(await _accountService.UpdateAccount(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            return Ok(await _accountService.DeleteAccount(id));
        }

    }
}
