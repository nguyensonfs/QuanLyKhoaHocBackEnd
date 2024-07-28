using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        private readonly ILoaiBaiVietService _loaiBaiVietService;
        private readonly IQuyenHanService _quyenHanService;

        public UserController(ILoaiKhoaHocService loaiKhoaHocService, ILoaiBaiVietService loaiBaiVietService, IQuyenHanService quyenHanService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
            _loaiBaiVietService = loaiBaiVietService;
            _quyenHanService = quyenHanService;
        }


        [HttpGet("GetAllLoaiKhoaHoc")]
        public async Task<IActionResult> GetAllLoaiKhoahocs()
        {
            return Ok(await _loaiKhoaHocService.GetAllLoaiKhoahocs());
        }

        [HttpGet("GetAllLoaiBaiViets")]
        public async Task<IActionResult> GetAllLoaiBaiViets()
        {
            return Ok(await _loaiBaiVietService.GetAllLoaiBaiViets());
        }

        [HttpGet("GetAllQuyenHan")]
        public async Task<IActionResult> GetAllQuyenHans()
        {
            return Ok(await _quyenHanService.GetAllQuyenHans());
        }
    }
}
