using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudent;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IStudentService
    {
        Task<PageResult<DataResponseStudent>> GetAlls(int pageSize, int pageNumber);
        Task<PageResult<DataResponseStudent>> SearchPagedStudents(string keyword, int pageNumber, int pageSize);
        Task<ResponseObject<DataResponseStudent>> CreateSudent(Request_CreateStudent request);
        Task<ResponseObject<DataResponseStudent>> UpdateSudent(int studentId,Request_UpdateStudent request);
        Task<string> DeleteStudent(int studentId);
    }
}
