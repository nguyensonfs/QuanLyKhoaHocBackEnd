using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.RoleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataRole;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class RoleService : IRoleService
    {
        private readonly IBaseRepository<QuyenHan> _baseRoleRepository;
        private readonly RoleConverter _roleConverter;

        public RoleService(IBaseRepository<QuyenHan> baseRoleRepository,
                           RoleConverter roleConverter)
        {
            _baseRoleRepository = baseRoleRepository;
            _roleConverter = roleConverter;
        }

        public async Task<PageResult<DataResponseRole>> GetAllRoles(int pageSize, int pageNumber)
        {
            var roles = await _baseRoleRepository.GetAllAsync().Result.ToListAsync();
            var query = roles.Select(x => _roleConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }
        public async Task<ResponseObject<DataResponseRole>> CreateRole(Request_CreateRole request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenQuyenHan))
                {
                    return new ResponseObject<DataResponseRole>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }

                var quyenHan = new QuyenHan
                {
                    TenQuyenHan = request.TenQuyenHan,
                };

                quyenHan = await _baseRoleRepository.CreateAsync(quyenHan);

                return new ResponseObject<DataResponseRole>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo quyền hạn thành công",
                    Data = _roleConverter.EntityToDTO(quyenHan)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseRole>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }
        }
        public async Task<ResponseObject<DataResponseRole>> UpdateRole(int roleId, Request_UpdateRole request)
        {
            try
            {
                var quyenHan = await _baseRoleRepository.GetByIdAsync(roleId);
                if (quyenHan == null)
                {
                    return new ResponseObject<DataResponseRole>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy quyền hạn này",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.TenQuyenHan))
                {
                    return new ResponseObject<DataResponseRole>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                quyenHan.TenQuyenHan = request.TenQuyenHan;
                quyenHan = await _baseRoleRepository.UpdateAsync(quyenHan);

                return new ResponseObject<DataResponseRole>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật quyền hạn thành công",
                    Data = _roleConverter.EntityToDTO(quyenHan)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseRole>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }
        public async Task<string> DeleteRole(int roleId)
        {
            var quyenHan = await _baseRoleRepository.GetByIdAsync(roleId);
            if (quyenHan == null)
            {
                return "không tìm thấy quyền hạn đó";
            }
            await _baseRoleRepository.DeleteAsync(roleId);
            return "Xoá thành công";
        }

    }
}
