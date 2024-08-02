using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.KhoaHocRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IKhoaHocService _khoaHocService;

        public CoursesController(IKhoaHocService khoaHocService)
        {
            _khoaHocService = khoaHocService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllsKhoaHoc(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _khoaHocService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("byname/{courseName}")]
        public async Task<IActionResult> GetKhoaHocByName( string courseName)
        {
            return Ok(await _khoaHocService.GetKhoaHocByName(courseName));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPagedKhoaHocsByName(string search, int page = 1, int pageSize = 10)
        {
            var result = await _khoaHocService.SearchPagedKhoaHocsByName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ThemKhoaHoc([FromForm] Request_ThemKhoaHoc request)
        {
            return Ok(await _khoaHocService.ThemKhoaHoc(request));
        }

        [HttpPut("{couseId}")]
        public async Task<IActionResult> SuaThongTinKhoaHoc(int couseId, [FromForm] Request_SuaKhoaHoc request)
        {
            return Ok(await _khoaHocService.CapNhatThongTinKhoaHoc(couseId,request));
        }

        [HttpDelete("{couseId}")]
        public async Task<IActionResult> XoaKhoaHoc([FromRoute] int couseId)
        {
            return Ok(await _khoaHocService.XoaKhoaHoc(couseId));
        }
    }
}
