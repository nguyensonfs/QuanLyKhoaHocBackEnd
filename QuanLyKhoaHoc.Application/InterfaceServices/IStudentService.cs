using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudent;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IStudentService
    {
        Task<ResponseObject<DataResponseStudent>> CreateSudent(Request_AddStudent request);
        Task<ResponseObject<DataResponseStudent>> UpdateSudent(Request_UpdateStudent request);
    }
}
