using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudent;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IStudentService
    {
        Task<ResponseObject<DataResponseStudent>> CreateSudent(Request_AddStudent request);
        Task<ResponseObject<DataResponseStudent>> UpdateSudent(Request_UpdateStudent request);
        Task<PageResult<DataResponseStudent>> GetAlls(int pageSize, int pageNumber);
        Task<PageResult<DataResponseStudent>> SearchPagedStudents(string keyword, int pageNumber, int pageSize);
        Task<string> DeleteStudent(int studentId);
    }
}
