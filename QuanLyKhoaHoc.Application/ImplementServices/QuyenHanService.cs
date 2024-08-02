using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.QuyenHanRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataQuyenHan;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class QuyenHanService : IQuyenHanService
    {
        private readonly IBaseRepository<QuyenHan> _baseQuyenHanRepository;
        private readonly QuyenHanConverter _converter;

        public QuyenHanService(IBaseRepository<QuyenHan> baseQuyenHanRepository, QuyenHanConverter converter)
        {
            _baseQuyenHanRepository = baseQuyenHanRepository;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseQuyenHan>> CapNhatThongTinQuyenHan(int roleId, Request_SuaQuyenHan request)
        {
            try
            {
                var quyenHan = await _baseQuyenHanRepository.GetByIdAsync(roleId);
                if (quyenHan == null)
                {
                    return new ResponseObject<DataResponseQuyenHan>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy quyền hạn này",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.TenQuyenHan))
                {
                    return new ResponseObject<DataResponseQuyenHan>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                quyenHan.TenQuyenHan = request.TenQuyenHan;
                quyenHan = await _baseQuyenHanRepository.UpdateAsync(quyenHan);

                return new ResponseObject<DataResponseQuyenHan>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật loại khoá học thành công",
                    Data = _converter.EntityToDTO(quyenHan)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseQuyenHan>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }

        public async Task<IQueryable<DataResponseQuyenHan>> GetAllQuyenHans()
        {
            var loaiQuyenHan = await _baseQuyenHanRepository.GetAllAsync().Result.ToListAsync();
            var dtoList = loaiQuyenHan.Select(x => _converter.EntityToDTO(x)).AsQueryable();
            return dtoList;
        }

        public async Task<ResponseObject<DataResponseQuyenHan>> ThemQuyenHan(Request_ThemQuyenHan request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenQuyenHan))
                {
                    return new ResponseObject<DataResponseQuyenHan>
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

                quyenHan = await _baseQuyenHanRepository.CreateAsync(quyenHan);

                return new ResponseObject<DataResponseQuyenHan>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo quyền hạn thành công",
                    Data = _converter.EntityToDTO(quyenHan)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseQuyenHan>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }
        }

        public async Task<string> XoaQuyenHan(int quyenHanId)
        {
            var quyenHan = await _baseQuyenHanRepository.GetByIdAsync(quyenHanId);
            if (quyenHan == null)
            {
                return "không tìm thấy quyền hạn đó";
            }
            await _baseQuyenHanRepository.DeleteAsync(quyenHanId);
            return "Xoá thành công";
        }
    }
}
