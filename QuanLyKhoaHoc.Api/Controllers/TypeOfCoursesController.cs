using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TypeOfCoursesController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;

        public TypeOfCoursesController(ILoaiKhoaHocService loaiKhoaHocService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _loaiKhoaHocService.GetAllLoaiKhoahocs());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Request_ThemLoaiKhoaHoc request)
        {
            return Ok(await _loaiKhoaHocService.ThemLoaiKhoaHoc(request));
        }

        [HttpPut("{typeofcourseId}")]
        public async Task<IActionResult> Upadate(int typeofcourseId, [FromBody] Request_SuaLoaiKhoaHoc request)
        {
            return Ok(await _loaiKhoaHocService.CapNhatThongTinLoaiKhoaHoc(typeofcourseId, request));
        }

        [HttpDelete("{typeofcourseId}")]
        public async Task<IActionResult> Delete([FromRoute] int typeofcourseId)
        {
            return Ok(await _loaiKhoaHocService.XoaLoaiKhoaHoc(typeofcourseId));
        }

    }
}
