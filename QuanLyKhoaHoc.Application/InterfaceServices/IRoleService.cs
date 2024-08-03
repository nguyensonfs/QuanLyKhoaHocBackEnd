using QuanLyKhoaHoc.Application.Payloads.RequestModels.RoleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataQuyenHan;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IRoleService
    {
        Task<IQueryable<DataResponseQuyenHan>> GetAllRoles();
        Task<ResponseObject<DataResponseQuyenHan>> CreateRole(Request_CreateRole request);
        Task<ResponseObject<DataResponseQuyenHan>> UpdateRole(int roleId, Request_UpdateRole request);
        Task<string> DeleteRole(int roleId);
    }
}
