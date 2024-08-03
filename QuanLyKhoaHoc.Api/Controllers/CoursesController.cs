using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.CourseRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _courseService.GetAllCourses(pageSize, pageNumber));
        }

        [HttpGet("byname/{courseName}")]
        public async Task<IActionResult> GetCourseByName( string courseName)
        {
            return Ok(await _courseService.GetCourseByName(courseName));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPagedCoursesByName(string search, int page = 1, int pageSize = 10)
        {
            var result = await _courseService.SearchPagedCoursesByName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Request_CreateCourse request)
        {
            return Ok(await _courseService.CreateCourse(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Request_UpdateCourse request)
        {
            return Ok(await _courseService.UpdateCourse(id,request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            return Ok(await _courseService.DeleteCourse(id));
        }
    }
}
