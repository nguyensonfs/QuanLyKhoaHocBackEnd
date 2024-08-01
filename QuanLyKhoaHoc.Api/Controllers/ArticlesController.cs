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
        public async Task<IActionResult> GetAllArticles(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _articleService.GetAlls(pageSize, pageNumber));
        }

        [HttpGet("{articleName}")]
        public async Task<IActionResult> GetAllArticles(string articleName)
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
        public async Task<IActionResult> Create([FromForm] Request_Create request)
        {
            return Ok(await _articleService.AddArticle(request));
        }

        [HttpPut("{articleId}")]
        public async Task<IActionResult> UpdateArticle(int articleId, [FromBody] Request_Update request)
        {
            return Ok(await _articleService.UpdateArticle(articleId,request));
        }

        [HttpDelete("{articleId}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int articleId)
        {
            return Ok(await _articleService.Delete(articleId));
        }
    }
}
