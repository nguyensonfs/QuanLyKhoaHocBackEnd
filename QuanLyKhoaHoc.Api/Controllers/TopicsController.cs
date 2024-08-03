using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TopicRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _topicService.GetAllTopics(pageSize, pageNumber));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            return Ok(await _topicService.GetTopicById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create( Request_CreateTopic request)
        {
            return Ok(await _topicService.CreateTopic(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,  Request_UpdateTopic request)
        {
            return Ok(await _topicService.UpdateTopic(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _topicService.DeleteTopic(id));    
        }

    }
}
