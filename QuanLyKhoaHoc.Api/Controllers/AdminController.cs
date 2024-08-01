using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.QuyenHanRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentStatusRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        private readonly ILoaiBaiVietService _loaiBaiVietService;
        private readonly IQuyenHanService _quyenHanService;
        private readonly IStudentStatusService _studentStatusService;

        public AdminController(ILoaiKhoaHocService loaiKhoaHocService,
                               ILoaiBaiVietService loaiBaiVietService,
                               IQuyenHanService quyenHananService,
                               IStudentStatusService studentStatusService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
            _loaiBaiVietService = loaiBaiVietService;
            _quyenHanService = quyenHananService;
            _studentStatusService = studentStatusService;
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

        [HttpPost("ThemQuyenHan")]
        public async Task<IActionResult> ThemQuyenHan([FromBody] Request_ThemQuyenHan request)
        {
            return Ok(await _quyenHanService.ThemQuyenHan(request));
        }

        [HttpPut("CapNhatThongTinQuyenHan")]
        public async Task<IActionResult> CapNhatThongTinQuyenHan([FromBody] Request_SuaQuyenHan request)
        {
            return Ok(await _quyenHanService.CapNhatThongTinQuyenHan(request));
        }

        [HttpDelete("XoaQuyenHan/{quyenHanID}")]
        public async Task<IActionResult> XoaQuyenHan([FromRoute] int quyenHanID)
        {
            return Ok(await _quyenHanService.XoaQuyenHan(quyenHanID));
        }

        [HttpPost("CreateStudentStatus")]
        public async Task<IActionResult> CreateStudentStatus([FromBody] Request_CreateStudentStatus request)
        {
            return Ok(await _studentStatusService.CreateStudentStatus(request));
        }

        [HttpPut("UpdateStudentStatus")]
        public async Task<IActionResult> UpdateStudentStatus([FromBody] Request_UpdateStudentStatus request)
        {
            return Ok(await _studentStatusService.UpdateStudentStatus(request));
        }
    }
}
