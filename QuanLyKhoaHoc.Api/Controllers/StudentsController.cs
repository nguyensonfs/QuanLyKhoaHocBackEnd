using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _studentService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search( string search, int page = 1, int pageSize = 10)
        {
            var result = await _studentService.SearchPagedStudents(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Request_CreateStudent request)
        {
            return Ok(await _studentService.CreateSudent(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Request_UpdateStudent request)
        {
            return Ok(await _studentService.UpdateSudent(id,request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            return Ok(await _studentService.DeleteStudent(id));
        }
    }
}
