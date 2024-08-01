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
        public async Task<IActionResult> GetPagedStudents(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _studentService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStudents([FromQuery] string search, int page = 1, int pageSize = 10)
        {
            var result = await _studentService.SearchPagedStudents(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromForm] Request_AddStudent request)
        {
            return Ok(await _studentService.CreateSudent(request));
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateSudent(int studentId, [FromForm] Request_UpdateStudent request)
        {
            return Ok(await _studentService.UpdateSudent(studentId,request));
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int studentId)
        {
            return Ok(await _studentService.DeleteStudent(studentId));
        }
    }
}
