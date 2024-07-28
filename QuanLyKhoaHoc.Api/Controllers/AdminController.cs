using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        private readonly ILoaiBaiVietService _loaiBaiVietService;

        public AdminController(ILoaiKhoaHocService loaiKhoaHocService, ILoaiBaiVietService loaiBaiVietService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
            _loaiBaiVietService = loaiBaiVietService;
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


        [HttpPost("ThemLoaiBaiViet")]
        public async Task<IActionResult> ThemLoaiBaiViet([FromBody] Request_ThemLoaiBaiViet request)
        {
            return Ok(await _loaiBaiVietService.ThemLoaiBaiViet(request));
        }

        [HttpPut("CapNhatThongTinLoaiBaiViet")]
        public async Task<IActionResult> CapNhatThongTinLoaiBaiViet([FromBody] Request_SuaLoaiBaiViet request)
        {
            return Ok(await _loaiBaiVietService.CapNhatThongTinLoaiBaiViet(request));
        }

        [HttpDelete("XoaLoaiBaiViet/{loaiBaiVietId}")]
        public async Task<IActionResult> XoaLoaiBaiViet([FromRoute] int loaiBaiVietId)
        {
            return Ok(await _loaiBaiVietService.XoaLoaiBaiViet(loaiBaiVietId));
        }

    }
}
