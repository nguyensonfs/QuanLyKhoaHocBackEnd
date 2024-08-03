using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataUsers;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IAccountService
    {
        Task<PageResult<DataResponseUser>> GetAlls(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseUser>> GetAccountbyName(string keyword);
        Task<PageResult<DataResponseUser>> SearchPagedAccountbyName(string keyword, int pageNumber, int pageSize);
        Task<ResponseObject<DataResponseUser>> CreateAccount(Request_CreateAccount request);
        Task<ResponseObject<DataResponseUser>> UpdateAccount(int accountId,Request_UpdateAccount request);
        Task<string> DeleteAccount(int accountId);
    }
}
