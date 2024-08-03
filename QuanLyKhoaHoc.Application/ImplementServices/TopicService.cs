using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TopicRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTopic;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class TopicService : ITopicService
    {
        private readonly IBaseRepository<ChuDe> _baseTopicRepository;
        private readonly TopicConverter _topicConverter;
        private readonly IBaseRepository<LoaiBaiViet> _baseTypeOfArticleRepository;

        public TopicService(IBaseRepository<ChuDe> baseTopicRepository,
                            TopicConverter topicConverter,
                            IBaseRepository<LoaiBaiViet> baseTypeOfArticleRepository)
        {
            _baseTopicRepository = baseTopicRepository;
            _topicConverter = topicConverter;
            _baseTypeOfArticleRepository = baseTypeOfArticleRepository;
        }

        public async Task<PageResult<DataResponseTopic>> GetAllTopics(int pageSize, int pageNumber)
        {
            var topics = await _baseTopicRepository.GetAllAsync().Result.ToListAsync();
            var query = topics.Select(x => _topicConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }
        public async Task<ResponseObject<DataResponseTopic>> GetTopicById(int topicId)
        {
            var topic = await _baseTopicRepository.GetByIdAsync(topicId);
            if (topic == null)
            {
                return new ResponseObject<DataResponseTopic>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Không tìm thấy chủ đề",
                    Data = null
                };
            }

            return new ResponseObject<DataResponseTopic>
            {
                Status = StatusCodes.Status200OK,
                Message = "Tìm thấy chủ đề",
                Data = _topicConverter.EntityToDTO(topic)
            };
        }
        public async Task<ResponseObject<DataResponseTopic>> CreateTopic(Request_CreateTopic request)
        {
            try
            {
                var typeOfArticle = await _baseTypeOfArticleRepository.GetByIdAsync(request.LoaiBaiVietID);
                if (typeOfArticle == null)
                {
                    return new ResponseObject<DataResponseTopic>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy chủ đề",
                        Data = null
                    };
                }

                var topic = new ChuDe
                {
                    TenChuDe = request.TenChuDe,
                    NoiDung = request.NoiDung,
                    LoaiBaiVietID = request.LoaiBaiVietID,
                };

                topic = await _baseTopicRepository.CreateAsync(topic);

                return new ResponseObject<DataResponseTopic>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo chủ đề thành công",
                    Data = _topicConverter.EntityToDTO(topic)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseTopic>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }
        public async Task<ResponseObject<DataResponseTopic>> UpdateTopic(int topicId, Request_UpdateTopic request)
        {
            try
            {
                var topic = await _baseTopicRepository.GetByIdAsync(topicId);
                if (topic == null)
                {
                    return new ResponseObject<DataResponseTopic>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy chủ đề",
                        Data = null
                    };
                }
                var typeOfArticle = await _baseTypeOfArticleRepository.GetByIdAsync(request.LoaiBaiVietID);
                if (typeOfArticle == null)
                {
                    return new ResponseObject<DataResponseTopic>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm loại bài viết",
                        Data = null
                    };
                }

                topic.TenChuDe = request.TenChuDe;
                topic.NoiDung = request.NoiDung;
                topic.LoaiBaiVietID = request.LoaiBaiVietID;

                topic = await _baseTopicRepository.UpdateAsync(topic);
                return new ResponseObject<DataResponseTopic>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật chủ đề thành công",
                    Data = _topicConverter.EntityToDTO(topic)
                };
            }
            catch (Exception e)
            {

                return new ResponseObject<DataResponseTopic>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Error : " + e.Message,
                    Data = null
                };
            }
        }
        public async Task<string> DeleteTopic(int topicId)
        {
            var topic = await _baseTopicRepository.GetByIdAsync(topicId);
            if (topic == null)
            {
                return "Không tìm thấy chủ đề";
            }
            await _baseTopicRepository.DeleteAsync(topicId);
            return "Xoá thành công";
        }
    }
}

