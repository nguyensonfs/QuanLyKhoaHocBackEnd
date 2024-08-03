using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfCourseRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTypeOfCourse;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;


namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class TypeOfCourseService : ITypeOfCourseService
    {
        private readonly IBaseRepository<LoaiKhoaHoc> _baseTypeOfCourseRepository;
        private readonly TypeOfCourseConverter _typeOfCourseConverter;

        public TypeOfCourseService(IBaseRepository<LoaiKhoaHoc> baseTypeOfCourseRepository,
                                   TypeOfCourseConverter typeOfCourseConverter)
        {
            _baseTypeOfCourseRepository = baseTypeOfCourseRepository;
            _typeOfCourseConverter = typeOfCourseConverter;
        }

        public async Task<PageResult<DataResponseTypeOfCourse>> GetAllTypeOfCourses(int pageSize, int pageNumber)
        {
            var loaiKhoaHocs = await _baseTypeOfCourseRepository.GetAllAsync().Result.ToListAsync();
            var dtoList = loaiKhoaHocs.Select(x => _typeOfCourseConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(dtoList, pageSize, pageNumber);
            return result;
        }
        public async Task<ResponseObject<DataResponseTypeOfCourse>> CreateTypeOfCourse(Request_CreateTypeOfCourse request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenLoaiKhoaHoc))
                {
                    return new ResponseObject<DataResponseTypeOfCourse>
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

                loaiKhoaHoc = await _baseTypeOfCourseRepository.CreateAsync(loaiKhoaHoc);

                return new ResponseObject<DataResponseTypeOfCourse>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo loại khoá học thành công",
                    Data = _typeOfCourseConverter.EntityToDTO(loaiKhoaHoc)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseTypeOfCourse>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }

        }
        public async Task<ResponseObject<DataResponseTypeOfCourse>> UpdateTypeOfCourse(int courseId, Request_UpdateTypeOfCourse request)
        {
            try
            {
                var loaiKhoaHoc = await _baseTypeOfCourseRepository.GetByIdAsync(courseId);
                if (loaiKhoaHoc == null)
                {
                    return new ResponseObject<DataResponseTypeOfCourse>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại khóa học",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.TenLoaiKhoaHoc))
                {
                    return new ResponseObject<DataResponseTypeOfCourse>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                loaiKhoaHoc.TenLoai = request.TenLoaiKhoaHoc;
                loaiKhoaHoc = await _baseTypeOfCourseRepository.UpdateAsync(loaiKhoaHoc);

                return new ResponseObject<DataResponseTypeOfCourse>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật loại khoá học thành công",
                    Data = _typeOfCourseConverter.EntityToDTO(loaiKhoaHoc)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseTypeOfCourse>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }
        public async Task<string> DeleteTypeOfCourse(int typeOfCourseId)
        {
            var loaiKhoaHoc = await _baseTypeOfCourseRepository.GetByIdAsync(typeOfCourseId);
            if (loaiKhoaHoc == null)
            {
                return "Không tìm thấy loại khoá học";
            }
            await _baseTypeOfCourseRepository.DeleteAsync(typeOfCourseId);
            return "Xoá thành công";
        }
    }
}
