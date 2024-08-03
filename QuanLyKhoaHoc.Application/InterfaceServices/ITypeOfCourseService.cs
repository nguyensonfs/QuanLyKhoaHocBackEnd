using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfCourseRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTypeOfCourse;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ITypeOfCourseService
    {
        Task<IQueryable<DataResponseTypeOfCourse>> GetAllTypeOfCourses();
        Task<ResponseObject<DataResponseTypeOfCourse>> CreateTypeOfCourse(Request_CreateTypeOfCourse request);
        Task<ResponseObject<DataResponseTypeOfCourse>> UpdateTypeOfCourse(int courseId,Request_UpdateTypeOfCourse request);
        Task<string> DeleteTypeOfCourse(int typeOfCourseId);
    }
}
