using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TopicRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataChuDe;
using QuanLyKhoaHoc.Application.Payloads.Responses;

namespace QuanLyKhoaHoc.Application.InterfaceServices
{
    public interface ITopicService
    {
        Task<PageResult<DataResponseChuDe>> GetAllTopics(int pageSize, int pageNumber);
        Task<ResponseObject<DataResponseChuDe>> GetTopicById(int topicId);
        Task<ResponseObject<DataResponseChuDe>> CreateTopic(Request_CreateTopic request);
        Task<ResponseObject<DataResponseChuDe>> UpdateTopic(int topicId,Request_UpdateTopic request);
        Task<string> DeleteTopic(int topicId);
    }
}
