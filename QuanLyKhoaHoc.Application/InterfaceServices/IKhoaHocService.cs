using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.KhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IKhoaHocService
    {
        Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(Request_ThemKhoaHoc request);
        Task<ResponseObject<DataResponseKhoaHoc>> CapNhatThongTinKhoaHoc(Request_SuaKhoaHoc request);
        Task<PageResult<DataResponseKhoaHoc>> GetAlls(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseKhoaHoc>> GetKhoaHocByName(string tenKhoaHoc);
        Task<PageResult<DataResponseKhoaHoc>> SearchPagedKhoaHocsByName(string tenKhoaHoc, int pageNumber, int pageSize);
        Task<string> XoaKhoaHoc(int khoaHocID);
        //Task<IQueryable<DataResponseKhoaHoc>> GetAllKhoaHocs();
    }
}
