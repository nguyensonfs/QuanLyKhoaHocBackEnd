using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ITypeOfCourseService
    {
        Task<IQueryable<DataResponseLoaiKhoaHoc>> GetAllTypeOfCourses();
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> CreateTypeOfCourse(Request_CreateTypeOfCourse request);
        Task<ResponseObject<DataResponseLoaiKhoaHoc>> UpdateTypeOfCourse(int courseId,Request_UpdateTypeOfCourse request);
        Task<string> DeleteTypeOfCourse(int typeOfCourseId);
    }
}
