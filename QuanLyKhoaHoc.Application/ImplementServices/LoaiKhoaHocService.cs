using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;


namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class LoaiKhoaHocService : ILoaiKhoaHocService
    {
        private readonly IBaseRepository<LoaiKhoaHoc> _baseLoaiKhoaHocRepository;
        private readonly LoaiKhoaHocConverter _converter;

        public LoaiKhoaHocService(IBaseRepository<LoaiKhoaHoc> baseLoaiKhoaHocRepository, LoaiKhoaHocConverter converter)
        {
            _baseLoaiKhoaHocRepository = baseLoaiKhoaHocRepository;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseLoaiKhoaHoc>> CapNhatThongTinLoaiKhoaHoc(int courseId, Request_SuaLoaiKhoaHoc request)
        {
            try
            {
                var loaiKhoaHoc = await _baseLoaiKhoaHocRepository.GetByIdAsync(courseId);
                if (loaiKhoaHoc == null)
                {
                    return new ResponseObject<DataResponseLoaiKhoaHoc>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại khóa học",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.TenLoaiKhoaHoc))
                {
                    return new ResponseObject<DataResponseLoaiKhoaHoc>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                loaiKhoaHoc.TenLoai = request.TenLoaiKhoaHoc;
                loaiKhoaHoc = await _baseLoaiKhoaHocRepository.UpdateAsync(loaiKhoaHoc);

                return new ResponseObject<DataResponseLoaiKhoaHoc>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật loại khoá học thành công",
                    Data = _converter.EntityToDTO(loaiKhoaHoc)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseLoaiKhoaHoc>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }



        public async Task<IQueryable<DataResponseLoaiKhoaHoc>> GetAllLoaiKhoahocs()
        {
            var loaiKhoaHocs = await _baseLoaiKhoaHocRepository.GetAllAsync().Result.ToListAsync();
            var dtoList = loaiKhoaHocs.Select(x => _converter.EntityToDTO(x)).AsQueryable();
            return dtoList;
        }

        public async Task<ResponseObject<DataResponseLoaiKhoaHoc>> ThemLoaiKhoaHoc(Request_ThemLoaiKhoaHoc request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenLoaiKhoaHoc))
                {
                    return new ResponseObject<DataResponseLoaiKhoaHoc>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }

                var loaiKhoaHoc = new LoaiKhoaHoc
                {
                    TenLoai = request.TenLoaiKhoaHoc
                };

                loaiKhoaHoc = await _baseLoaiKhoaHocRepository.CreateAsync(loaiKhoaHoc);

                return new ResponseObject<DataResponseLoaiKhoaHoc>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo loại khoá học thành công",
                    Data = _converter.EntityToDTO(loaiKhoaHoc)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseLoaiKhoaHoc>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }

        }

        public async Task<string> XoaLoaiKhoaHoc(int loaiKhoaHocId)
        {
            var loaiKhoaHoc = await _baseLoaiKhoaHocRepository.GetByIdAsync(loaiKhoaHocId);
            if (loaiKhoaHoc == null)
            {
                return "không tìm thấy khoá học";
            }
            await _baseLoaiKhoaHocRepository.DeleteAsync(loaiKhoaHocId);
            return "Xoá thành công";
        }
    }
}
