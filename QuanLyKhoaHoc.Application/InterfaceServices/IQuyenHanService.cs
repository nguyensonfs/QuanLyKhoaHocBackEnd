using QuanLyKhoaHoc.Application.Payloads.RequestModels.QuyenHanRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataQuyenHan;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IQuyenHanService
    {
        Task<ResponseObject<DataResponseQuyenHan>> ThemQuyenHan(Request_ThemQuyenHan request);
        Task<ResponseObject<DataResponseQuyenHan>> CapNhatThongTinQuyenHan(int roleId,Request_SuaQuyenHan request);
        Task<string> XoaQuyenHan(int quyenHanId);
        Task<IQueryable<DataResponseQuyenHan>> GetAllQuyenHans();
    }
}
