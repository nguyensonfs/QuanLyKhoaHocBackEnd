using QuanLyKhoaHoc.Application.Payloads.RequestModels.LearningStatusRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ILearningStatusService
    {
        Task<IQueryable<DataResponseLearningStatus>> GetAllLearningStatuses();
        Task<ResponseObject<DataResponseLearningStatus>> CreateLearningStatus(Request_CreateLearningStatus request);
        Task<ResponseObject<DataResponseLearningStatus>> UpdateLearningStatus(int studentStatusId, Request_UpdateLearningStatus request);
        Task<string> DeleteLearningStatus(int statusId);
    }
}
