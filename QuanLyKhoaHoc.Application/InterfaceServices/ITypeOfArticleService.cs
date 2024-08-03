using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTypeOfArticle;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ITypeOfArticleService
    {
        Task<IQueryable<DataResponseTypeOfArticle>> GetAllTypeOfArticles();
        Task<ResponseObject<DataResponseTypeOfArticle>> CreateTypeOfArticle(Request_CreateTypeOfArticle request);
        Task<ResponseObject<DataResponseTypeOfArticle>> UpdateTypeOfArticle(int typeofArticleId,Request_UpdateTypeOfArticle request);
        Task<string> DeleteTypeOfArticle(int typeOfArticleId);
    }
}
