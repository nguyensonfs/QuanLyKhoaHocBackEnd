using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.CourseRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataCourse;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ICourseService
    {
        Task<PageResult<DataResponseCourse>> GetAllCourses(int pageSize, int pageNumber);
        Task<PageResult<DataResponseCourse>> SearchPagedCoursesByName(string nameCourse, int pageNumber, int pageSize);
        Task<ResponseObject<DataResponseCourse>> GetCourseByName(string nameCourse);
        Task<ResponseObject<DataResponseCourse>> CreateCourse(Request_CreateCourse request);
        Task<ResponseObject<DataResponseCourse>> UpdateCourse(int courseId,Request_UpdateCourse request);
        Task<string> DeleteCourse(int courseId);
    }
}
