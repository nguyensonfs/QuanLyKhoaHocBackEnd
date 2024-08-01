using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        private readonly ILoaiBaiVietService _loaiBaiVietService;
        private readonly IQuyenHanService _quyenHanService;
        private readonly IChuDeService _chuDeService;
        private readonly IStudentStatusService _studentStatusService;
        private readonly IAccountService _accountService;

        public UserController(ILoaiKhoaHocService loaiKhoaHocService,
                              ILoaiBaiVietService loaiBaiVietService,
                              IQuyenHanService quyenHanService,
                              IChuDeService chuDeService,
                              IStudentStatusService studentStatusService,
                              IAccountService accountService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
            _loaiBaiVietService = loaiBaiVietService;
            _quyenHanService = quyenHanService;
            _chuDeService = chuDeService;
            _studentStatusService = studentStatusService;
            _accountService = accountService;
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



        [HttpGet("GetAllsChuDe")]
        public async Task<IActionResult> GetAllsChuDe(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _chuDeService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("GetChuDeById")]
        public async Task<IActionResult> GetChuDeById([FromRoute] int chuDeId)
        {
            return Ok(await _chuDeService.GetChuDeById(chuDeId));
        }

        [HttpPost("ThemChuDe")]
        public async Task<IActionResult> ThemChuDe([FromBody] Request_AddChuDe request)
        {
            return Ok(await _chuDeService.AddChuDe(request));
        }

        [HttpPut("CapNhatChuDe")]
        public async Task<IActionResult> CapNhatChuDe([FromBody] Request_EditChuDe request)
        {
            return Ok(await _chuDeService.UpdateChuDe(request));
        }


        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            return Ok(await _studentStatusService.GetAlls());
        }





    }
}
