using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LearningStatusRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class LearningStatusService : ILearningStatusService
    {
        private readonly IBaseRepository<TinhTrangHoc> _baseLearningStatusRepository;
        private readonly LearningStatusConverter _learningStatusConverter;

        public LearningStatusService(IBaseRepository<TinhTrangHoc> baseLearningStatusRepository,
                                    LearningStatusConverter learningStatusConverter)
        {
            _baseLearningStatusRepository = baseLearningStatusRepository;
            _learningStatusConverter = learningStatusConverter;
        }

        public async Task<PageResult<DataResponseLearningStatus>> GetAllLearningStatuses(int pageSize,int pageNumber)
        {
            var query = await _baseLearningStatusRepository.GetAllAsync().Result.ToListAsync();
            var dtoList = query.Select(x => _learningStatusConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(dtoList, pageSize, pageNumber);
            return result;
        }
        public async Task<ResponseObject<DataResponseLearningStatus>> CreateLearningStatus(Request_CreateLearningStatus request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.StudentStatusName))
                {
                    return new ResponseObject<DataResponseLearningStatus>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }

                var learningStatus = new TinhTrangHoc
                {
                    TenTinhTrang = request.StudentStatusName
                };

                learningStatus = await _baseLearningStatusRepository.CreateAsync(learningStatus);

                return new ResponseObject<DataResponseLearningStatus>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo trạng thái học thành công",
                    Data = _learningStatusConverter.EntityToDTO(learningStatus)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseLearningStatus>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }
        }
        public async Task<ResponseObject<DataResponseLearningStatus>> UpdateLearningStatus(int studentStatusId, Request_UpdateLearningStatus request)
        {
            try
            {
                var learningStatus = await _baseLearningStatusRepository.GetByIdAsync(studentStatusId);
                if (learningStatus == null)
                {
                    return new ResponseObject<DataResponseLearningStatus>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Trạng thái học không tồn tại",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.StudentStatusName))
                {
                    return new ResponseObject<DataResponseLearningStatus>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                learningStatus.TenTinhTrang = request.StudentStatusName;
                learningStatus = await _baseLearningStatusRepository.UpdateAsync(learningStatus);

                return new ResponseObject<DataResponseLearningStatus>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật trạng thái học thành công",
                    Data = _learningStatusConverter.EntityToDTO(learningStatus)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseLearningStatus>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }
        public async Task<string> DeleteLearningStatus(int statusId)
        {
            var studentStatus = await _baseLearningStatusRepository.GetByIdAsync(statusId);
            if (studentStatus == null)
            {
                return "Trạng thái học không tồn tại";
            }
            await _baseLearningStatusRepository.DeleteAsync(statusId);
            return "Xoá thành công";
        }
    }
}
