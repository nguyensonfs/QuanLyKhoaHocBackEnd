using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataChuDe;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IChuDeService
    {
        Task<ResponseObject<DataResponseChuDe>> AddChuDe(Request_AddChuDe request);
    }
}
