using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentStatusRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LearningStatusesController : ControllerBase
    {
        private readonly IStudentStatusService _studentStatusService;

        public LearningStatusesController(IStudentStatusService studentStatusService)
        {
            _studentStatusService = studentStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            return Ok(await _studentStatusService.GetAlls());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentStatus([FromBody] Request_CreateStudentStatus request)
        {
            return Ok(await _studentStatusService.CreateStudentStatus(request));
        }

        [HttpPut("{statusId}")]
        public async Task<IActionResult> UpdateStudentStatus(int statusId, [FromBody] Request_UpdateStudentStatus request)
        {
            return Ok(await _studentStatusService.UpdateStudentStatus(statusId, request));
        }

        [HttpDelete("{statusId}")]
        public async Task<IActionResult> DeleteStatus(int statusId)
        {
            return Ok(await _studentStatusService.Delete(statusId));
        }
    }
}
