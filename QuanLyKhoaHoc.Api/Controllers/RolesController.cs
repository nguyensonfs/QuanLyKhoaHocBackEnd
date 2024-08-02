using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.QuyenHanRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IQuyenHanService _quyenHanService;

        public RolesController(IQuyenHanService quyenHanService)
        {
            _quyenHanService = quyenHanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _quyenHanService.GetAllQuyenHans());
        }

        [HttpPost]
        public async Task<IActionResult> Create( Request_ThemQuyenHan request)
        {
            return Ok(await _quyenHanService.ThemQuyenHan(request));
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> Update(int roleId, [FromBody] Request_SuaQuyenHan request)
        {
            return Ok(await _quyenHanService.CapNhatThongTinQuyenHan(roleId,request));
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> Delete( int roleId)
        {
            return Ok(await _quyenHanService.XoaQuyenHan(roleId));
        }
    }
}
