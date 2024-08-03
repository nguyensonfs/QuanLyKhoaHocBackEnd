using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandleImage;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.CourseRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataCourse;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class CourseService : ICourseService
    {
        private readonly IBaseRepository<KhoaHoc> _baseCourseRepository;
        private readonly IBaseRepository<LoaiKhoaHoc> _baseTypeOfCourseRepository;
        private readonly CourseConverter _courseConverter;

        public CourseService(IBaseRepository<KhoaHoc> baseCourseRepository,
                             CourseConverter courseConverter,
                             IBaseRepository<LoaiKhoaHoc> baseTypeOfCourseRepository)
        {
            _baseCourseRepository = baseCourseRepository;
            _baseTypeOfCourseRepository = baseTypeOfCourseRepository;
            _courseConverter = courseConverter;
        }

        public async Task<PageResult<DataResponseCourse>> GetAllCourses(int pageSize, int pageNumber)
        {
            var loaiBaiViets = await _baseCourseRepository.GetAllAsync().Result.ToListAsync();
            var query = loaiBaiViets.Select(x => _courseConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }
        public async Task<PageResult<DataResponseCourse>> SearchPagedCoursesByName(string nameCourse, int pageNumber, int pageSize)
        {
            var query = await _baseCourseRepository.GetAllAsync(kh => kh.TenKhoaHoc.ToLower().Contains(nameCourse.ToLower()));
            var pagedData = Pagination.GetPagedData(query, pageSize, pageNumber);
            var convertedItems = pagedData.Data.Select(course => _courseConverter.EntityToDTO(course)).AsQueryable();

            return new PageResult<DataResponseCourse>(convertedItems, pagedData.TotalItems, pagedData.TotalPages, pageNumber, pageSize);
        }
        public async Task<ResponseObject<DataResponseCourse>> GetCourseByName(string nameCourse)
        {
            var course = await _baseCourseRepository.GetAsync(x => x.TenKhoaHoc.ToLower().Contains(nameCourse.ToLower()));
            if (course == null)
            {
                return new ResponseObject<DataResponseCourse>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Không tìm thấy khoá học",
                    Data = null
                };
            }

            return new ResponseObject<DataResponseCourse>
            {
                Status = StatusCodes.Status200OK,
                Message = "Đã tìm thấy khoá học",
                Data = _courseConverter.EntityToDTO(course)
            };

        }
        public async Task<ResponseObject<DataResponseCourse>> CreateCourse(Request_CreateCourse request)
        {
            try
            {
                var loaiKhoaHoc = await _baseTypeOfCourseRepository.GetByIdAsync((int)request.LoaiKhoaHocID);
                if (loaiKhoaHoc == null)
                {
                    return new ResponseObject<DataResponseCourse>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy khoá học",
                        Data = null
                    };
                }

                var course = new KhoaHoc
                {
                    TenKhoaHoc = request.TenKhoaHoc,
                    HinhAnh = await HandleUploadImage.Upfile(request.HinhAnh),
                    GioiThieu = request.GioiThieu,
                    HocPhi = (float)request.HocPhi,
                    NoiDung = request.NoiDung,
                    SoLuongMon = (int)request.SoLuongMon,
                    SoHocVien = 0,
                    LoaiKhoaHocID = (int)request.LoaiKhoaHocID,
                };

                course = await _baseCourseRepository.CreateAsync(course);

                return new ResponseObject<DataResponseCourse>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo khoá học thành công",
                    Data = _courseConverter.EntityToDTO(course)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseCourse>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }
        public async Task<ResponseObject<DataResponseCourse>> UpdateCourse(int courseId, Request_UpdateCourse request)
        {
            try
            {
                var course = await _baseCourseRepository.GetByIdAsync(courseId);
                var loaiKhoaHoc = await _baseTypeOfCourseRepository.GetByIdAsync((int)request.LoaiKhoaHocID);
                if (course == null)
                {
                    return new ResponseObject<DataResponseCourse>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy khoá học",
                        Data = null
                    };
                }
                if (loaiKhoaHoc == null)
                {
                    return new ResponseObject<DataResponseCourse>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại khoá học",
                        Data = null
                    };
                }
                course.GioiThieu = request.GioiThieu;
                course.HinhAnh = await HandleUploadImage.Upfile(request.HinhAnh);
                course.HocPhi = (float)request.HocPhi;
                course.LoaiKhoaHocID = (int)request.LoaiKhoaHocID;
                course.TenKhoaHoc = request.TenKhoaHoc;
                course.NoiDung = request.NoiDung;
                course.SoLuongMon = (int)request.SoLuongMon;

                course = await _baseCourseRepository.UpdateAsync(course);
                return new ResponseObject<DataResponseCourse>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật khoá học thành công",
                    Data = _courseConverter.EntityToDTO(course)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseCourse>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }
        public async Task<string> DeleteCourse(int courseId)
        {
            var course = await _baseCourseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                return "không tìm thấy quyền hạn đó";
            }
            await _baseCourseRepository.DeleteAsync(courseId);
            return "Xoá thành công";
        }
    }
}
