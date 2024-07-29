using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataChuDe;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IChuDeService
    {
        Task<ResponseObject<DataResponseChuDe>> AddChuDe(Request_AddChuDe request);
        Task<ResponseObject<DataResponseChuDe>> UpdateChuDe(Request_EditChuDe request);
        Task<PageResult<DataResponseChuDe>> GetAlls(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseChuDe>> GetChuDeById(int chuDeId);
    }
}
