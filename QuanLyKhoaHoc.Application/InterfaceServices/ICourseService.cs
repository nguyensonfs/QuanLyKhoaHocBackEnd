using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.CourseRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ICourseService
    {
        Task<PageResult<DataResponseKhoaHoc>> GetAllCourses(int pageSize, int pageNumber);
        Task<PageResult<DataResponseKhoaHoc>> SearchPagedCoursesByName(string tenKhoaHoc, int pageNumber, int pageSize);
        Task<ResponseObject<DataResponseKhoaHoc>> GetCourseByName(string tenKhoaHoc);
        Task<ResponseObject<DataResponseKhoaHoc>> CreateCourse(Request_CreateCourse request);
        Task<ResponseObject<DataResponseKhoaHoc>> UpdateCourse(int couseId,Request_UpdateCourse request);
        Task<string> DeleteCourse(int khoaHocID);
    }
}
