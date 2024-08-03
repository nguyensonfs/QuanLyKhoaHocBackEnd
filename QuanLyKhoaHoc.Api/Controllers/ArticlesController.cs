using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ArticleRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _articleService.GetAllArticles(pageSize, pageNumber));
        }

        [HttpGet("byname/{articleName}")]
        public async Task<IActionResult> GetArticlebyName(string articleName)
        {
            return Ok(await _articleService.GetArticlebyName(articleName));
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchPagedArticles(string search, int page = 1, int pageSize = 10)
        {
            var result = await _articleService.SearchPagedArticlebyName(search, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Request_CreateArticle request)
        {
            return Ok(await _articleService.CreateArticle(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Request_UpdateArtice request)
        {
            return Ok(await _articleService.UpdateArticle(id,request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            return Ok(await _articleService.DeleteArticle(id));
        }
    }
}
