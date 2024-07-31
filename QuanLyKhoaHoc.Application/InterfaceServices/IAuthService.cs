using QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataAccounts;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IAuthService
    {
        Task<ResponseObject<DataResponseLogin>> GetJwtTokenAsync(TaiKhoan taiKhoan);
        Task<ResponseObject<DataResponseLogin>> Login(Request_Login request);
    }
}
