using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TypeOfArticlesController : ControllerBase
    {
        private readonly ILoaiBaiVietService _loaiBaiVietService;

        public TypeOfArticlesController(ILoaiBaiVietService loaiBaiVietService)
        {
            _loaiBaiVietService = loaiBaiVietService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _loaiBaiVietService.GetAllLoaiBaiViets());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Request_ThemLoaiBaiViet request)
        {
            return Ok(await _loaiBaiVietService.ThemLoaiBaiViet(request));
        }

        [HttpPut("{typeofArticleId}")]
        public async Task<IActionResult> CapNhatThongTinLoaiBaiViet(int typeofArticleId, Request_SuaLoaiBaiViet request)
        {
            return Ok(await _loaiBaiVietService.CapNhatThongTinLoaiBaiViet(typeofArticleId,request));
        }

        [HttpDelete("{typeofArticleId}")]
        public async Task<IActionResult> Delete(int typeofArticleId)
        {
            return Ok(await _loaiBaiVietService.XoaLoaiBaiViet(typeofArticleId));
        }
    }
}
