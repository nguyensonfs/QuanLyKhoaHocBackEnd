using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IChuDeService _chuDeService;

        public TopicsController(IChuDeService chuDeService)
        {
            _chuDeService = chuDeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllsChuDe(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _chuDeService.GetAlls(pageSize, pageNumber));
        }
        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetChuDeById(int topicId)
        {
            return Ok(await _chuDeService.GetChuDeById(topicId));
        }

        [HttpPost]
        public async Task<IActionResult> ThemChuDe([FromBody] Request_AddChuDe request)
        {
            return Ok(await _chuDeService.AddChuDe(request));
        }

        [HttpPut("{topicId}")]
        public async Task<IActionResult> CapNhatChuDe(int topicId, [FromBody] Request_EditChuDe request)
        {
            return Ok(await _chuDeService.UpdateChuDe(topicId,request));
        }
    }
}
