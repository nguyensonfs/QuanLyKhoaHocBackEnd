using QuanLyKhoaHoc.Application.Payloads.RequestModels.LearningStatusRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ILearningStatusService
    {
        Task<IQueryable<DataResponseStudentStatus>> GetAllLearningStatuses();
        Task<ResponseObject<DataResponseStudentStatus>> CreateLearningStatus(Request_CreateLearningStatus request);
        Task<ResponseObject<DataResponseStudentStatus>> UpdateLearningStatus(int studentStatusId, Request_UpdateLearningStatus request);
        Task<string> DeleteLearningStatus(int statusId);
    }
}
