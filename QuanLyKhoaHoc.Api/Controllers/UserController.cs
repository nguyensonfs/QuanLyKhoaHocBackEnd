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

        public UserController(ILoaiKhoaHocService loaiKhoaHocService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
        }


        [HttpGet("GetAllLoaiKhoaHoc")]
        public async Task<IActionResult> GetAllLoaiKhoahocs()
        {
            return Ok(await _loaiKhoaHocService.GetAllLoaiKhoahocs());
        }
    }
}
