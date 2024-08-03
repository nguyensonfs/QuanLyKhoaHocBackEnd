using QuanLyKhoaHoc.Application.Payloads.RequestModels.RoleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataRole;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IRoleService
    {
        Task<IQueryable<DataResponseRole>> GetAllRoles();
        Task<ResponseObject<DataResponseRole>> CreateRole(Request_CreateRole request);
        Task<ResponseObject<DataResponseRole>> UpdateRole(int roleId, Request_UpdateRole request);
        Task<string> DeleteRole(int roleId);
    }
}
