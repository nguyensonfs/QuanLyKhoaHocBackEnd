using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ILoaiKhoaHocService
    {
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request);
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> CapNhatThongTinLoaiKhoaHoc(Request_SuaLoaiKhoaHoc request);
        Task<string> XoaLoaiKhoaHoc(int loaiKhoaHocId);
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> GetAllLoaiKhoahocs();
    }
}
