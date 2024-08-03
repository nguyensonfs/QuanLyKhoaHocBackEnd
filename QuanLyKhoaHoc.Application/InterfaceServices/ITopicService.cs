using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TopicRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTopic;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ITopicService
    {
        Task<PageResult<DataResponseTopic>> GetAllTopics(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseTopic>> GetTopicById(int topicId);
        Task<ResponseObject<DataResponseTopic>> CreateTopic(Request_CreateTopic request);
        Task<ResponseObject<DataResponseTopic>> UpdateTopic(int topicId,Request_UpdateTopic request);
        Task<string> DeleteTopic(int topicId);
    }
}
