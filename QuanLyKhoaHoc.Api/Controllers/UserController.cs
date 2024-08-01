using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.KhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoaiKhoaHocService _loaiKhoaHocService;
        private readonly ILoaiBaiVietService _loaiBaiVietService;
        private readonly IQuyenHanService _quyenHanService;
        private readonly IKhoaHocService _khoaHocService;
        private readonly IChuDeService _chuDeService;
        private readonly IStudentService _studentService;
        private readonly IAuthService _authService;
        private readonly IStudentStatusService _studentStatusService;
        private readonly IArticleService _articleService;

        public UserController(ILoaiKhoaHocService loaiKhoaHocService,
                              ILoaiBaiVietService loaiBaiVietService,
                              IQuyenHanService quyenHanService,
                              IKhoaHocService khoaHocService,
                              IChuDeService chuDeService,
                              IStudentService studentService,
                              IAuthService authService,
                              IStudentStatusService studentStatusService,
                              IArticleService articleService)
        {
            _loaiKhoaHocService = loaiKhoaHocService;
            _loaiBaiVietService = loaiBaiVietService;
            _quyenHanService = quyenHanService;
            _khoaHocService = khoaHocService;
            _chuDeService = chuDeService;
            _studentService = studentService;
            _authService = authService;
            _studentStatusService = studentStatusService;
            _articleService = articleService;
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

        [HttpGet("GetAllsKhoaHoc")]
        public async Task<IActionResult> GetAllsKhoaHoc(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _khoaHocService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("GetKhoaHocByName")]
        public async Task<IActionResult> GetKhoaHocByName([FromQuery] string tenKhoaHoc)
        {
            return Ok(await _khoaHocService.GetKhoaHocByName(tenKhoaHoc));
        }

        [HttpGet("SearchPagedKhoaHocsByName")]
        public async Task<IActionResult> SearchPagedKhoaHocsByName(string search, int page = 1, int pageSize = 10)
        {
            var result = await _khoaHocService.SearchPagedKhoaHocsByName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost("ThemKhoaHoc")]
        public async Task<IActionResult> ThemKhoaHoc([FromForm] Request_ThemKhoaHoc request)
        {
            return Ok(await _khoaHocService.ThemKhoaHoc(request));
        }

        [HttpPut("SuaThongTinKhoaHoc")]
        public async Task<IActionResult> SuaThongTinKhoaHoc([FromForm] Request_SuaKhoaHoc request)
        {
            return Ok(await _khoaHocService.CapNhatThongTinKhoaHoc(request));
        }

        [HttpDelete("XoaKhoaHoc/{khoaHocId}")]
        public async Task<IActionResult> XoaKhoaHoc([FromRoute] int khoaHocId)
        {
            return Ok(await _khoaHocService.XoaKhoaHoc(khoaHocId));
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

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _studentService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("SearchPagedStudents")]
        public async Task<IActionResult> Search(string search, int page = 1, int pageSize = 10)
        {
            var result = await _studentService.SearchPagedStudents(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromForm] Request_AddStudent request)
        {
            return Ok(await _studentService.CreateSudent(request));
        }

        [HttpPut("UpdateSudent")]
        public async Task<IActionResult> UpdateSudent([FromForm] Request_UpdateStudent request)
        {
            return Ok(await _studentService.UpdateSudent(request));
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int studentId)
        {
            return Ok(await _studentService.DeleteStudent(studentId));
        }


        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            return Ok(await _studentStatusService.GetAlls());
        }

        [HttpGet("GetAllArticles")]
        public async Task<IActionResult> GetAllArticles(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _articleService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("GetAllArticlebyName")]
        public async Task<IActionResult> GetAllArticles(string keyword)
        {
            return Ok(await _articleService.GetArticlebyName(keyword));
        }


        [HttpGet("SearchPagedArticles")]
        public async Task<IActionResult> SearchPagedArticles(string search, int page = 1, int pageSize = 10)
        {
            var result = await _articleService.SearchPagedArticlebyName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost("AddArticle")]
        public async Task<IActionResult> Create([FromForm] Request_Create request)
        {
            return Ok(await _articleService.AddArticle(request));
        }

        [HttpPut("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle([FromBody] Request_Update request)
        {
            return Ok(await _articleService.UpdateArticle(request));
        }

        [HttpDelete("DeleteArticle/{articleId}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int articleId)
        {
            return Ok(await _articleService.Delete(articleId));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Request_Login login)
        {
            return Ok(await _authService.Login(login));
        }

    }
}
