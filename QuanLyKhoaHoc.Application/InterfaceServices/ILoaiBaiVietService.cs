using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiBaiViet;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ILoaiBaiVietService
    {
        Task<ResponseObject<DataResponseLoaiBaiViet>> ThemLoaiBaiViet(Request_ThemLoaiBaiViet request);
        Task<ResponseObject<DataResponseLoaiBaiViet>> CapNhatThongTinLoaiBaiViet(Request_SuaLoaiBaiViet request);
        Task<string> XoaLoaiBaiViet(int loaiBaiVietId);
        Task<IQueryable<DataResponseLoaiBaiViet>> GetAllLoaiBaiViets();
    }
}
