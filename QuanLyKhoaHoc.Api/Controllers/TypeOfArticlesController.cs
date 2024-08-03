using Microsoft.AspNetCore.Mvc;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfArticleRequests;

namespace QuanLyKhoaHoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TypeOfArticlesController : ControllerBase
    {
        private readonly ITypeOfArticleService _typeOfArticleService;

        public TypeOfArticlesController(ITypeOfArticleService typeOfArticleService)
        {
            _typeOfArticleService = typeOfArticleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            return Ok(await _typeOfArticleService.GetAllTypeOfArticles(pageSize, pageNumber));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Request_CreateTypeOfArticle request)
        {
            return Ok(await _typeOfArticleService.CreateTypeOfArticle(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Request_UpdateTypeOfArticle request)
        {
            return Ok(await _typeOfArticleService.UpdateTypeOfArticle(id,request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _typeOfArticleService.DeleteTypeOfArticle(id));
        }
    }
}
