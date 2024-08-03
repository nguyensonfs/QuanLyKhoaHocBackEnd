using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataArticles;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IArticleService
    {
        Task<PageResult<DataResponseArticle>> GetAllArticles(int pageSize, int pageNumber);
        Task<PageResult<DataResponseArticle>> SearchPagedArticlebyName(string keyword, int pageNumber, int pageSize);
        Task<ResponseObject<DataResponseArticle>> GetArticlebyName(string keyword);
        Task<ResponseObject<DataResponseArticle>> CreateArticle(Request_CreateArticle request);
        Task<ResponseObject<DataResponseArticle>> UpdateArticle(int articleId,Request_UpdateArtice request);
        Task<string> DeleteArticle(int articleId);
    }
}
