using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentStatusRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface IStudentStatusService
    {
        Task<ResponseObject<DataResponseStudentStatus>> CreateStudentStatus(Request_CreateStudentStatus request);
        Task<ResponseObject<DataResponseStudentStatus>> UpdateStudentStatus(Request_UpdateStudentStatus request);
    }
}
