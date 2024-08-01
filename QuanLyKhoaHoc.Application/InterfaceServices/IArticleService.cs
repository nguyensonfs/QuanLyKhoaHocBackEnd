using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataArticles;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IArticleService
    {
        Task<ResponseObject<DataResponseArticle>> AddArticle(Request_Create request);
        Task<ResponseObject<DataResponseArticle>> UpdateArticle(int articleId,Request_Update request);
        Task<PageResult<DataResponseArticle>> GetAlls(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseArticle>> GetArticlebyName(string keyword);
        Task<PageResult<DataResponseArticle>> SearchPagedArticlebyName(string keyword, int pageNumber, int pageSize);
        Task<string> Delete(int baivietId);
    }
}
