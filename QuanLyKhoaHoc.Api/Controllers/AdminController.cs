using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;

        public AdminController(ILoaiKhoaHocService loaiKhoaHocService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
        }


        [HttpPost("ThemLoaiKhoaHoc")]
        public async Task<IActionResult> ThemLoaiKhoaHoc([FromBody] Request_ThemLoaiKhoaHoc request)
        {
            return Ok(await _loaiKhoaHocService.ThemLoaiKhoaHoc(request));
        }

        [HttpPut("CapNhatThongTinLoaiKhoaHoc")]
        public async Task<IActionResult> CapNhatThongTinLoaiKhoaHoc([FromBody] Request_SuaLoaiKhoaHoc request)
        {
            return Ok(await _loaiKhoaHocService.CapNhatThongTinLoaiKhoaHoc(request));
        }

        [HttpDelete("XoaLoaiKhoaHoc/{loaiKhoaHocId}")]
        public async Task<IActionResult> XoaLoaiKhoaHoc([FromRoute] int loaiKhoaHocId)
        {
            return Ok(await _loaiKhoaHocService.XoaLoaiKhoaHoc(loaiKhoaHocId));
        }
    }
}
