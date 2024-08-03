using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiBaiViet;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ITypeOfArticleService
    {
        Task<IQueryable<DataResponseLoaiBaiViet>> GetAllTypeOfArticles();
        Task<ResponseObject<DataResponseLoaiBaiViet>> CreateTypeOfArticle(Request_CreateTypeOfArticle request);
        Task<ResponseObject<DataResponseLoaiBaiViet>> UpdateTypeOfArticle(int typeofArticleId,Request_UpdateTypeOfArticle request);
        Task<string> DeleteTypeOfArticle(int typeOfArticleId);
    }
}
