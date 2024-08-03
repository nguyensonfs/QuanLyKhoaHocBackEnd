using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LearningStatusRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LearningStatusesController : ControllerBase
    {
        private readonly ILearningStatusService _learningStatusService;

        public LearningStatusesController(ILearningStatusService learningStatusService)
        {
            _learningStatusService = learningStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _learningStatusService.GetAllLearningStatuses());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Request_CreateLearningStatus request)
        {
            return Ok(await _learningStatusService.CreateLearningStatus(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Request_UpdateLearningStatus request)
        {
            return Ok(await _learningStatusService.UpdateLearningStatus(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _learningStatusService.DeleteLearningStatus(id));
        }
    }
}
