using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataChuDe;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;
using System;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class ChuDeService : IChuDeService
    {
        private readonly IBaseRepository<ChuDe> _baseChuDeRepository;
        private readonly ChuDeConverter _chuDeConverter;
        private readonly IBaseRepository<LoaiBaiViet> _baseLoaiBaiVietRepository;

        public ChuDeService(IBaseRepository<ChuDe> baseChuDeRepository, ChuDeConverter chuDeConverter, IBaseRepository<LoaiBaiViet> baseLoaiBaiVietRepository)
        {
            _baseChuDeRepository = baseChuDeRepository;
            _chuDeConverter = chuDeConverter;
            _baseLoaiBaiVietRepository = baseLoaiBaiVietRepository;
        }

        public async Task<ResponseObject<DataResponseChuDe>> AddChuDe(Request_AddChuDe request)
        {
            try
            {
                var loaiBaiViet = await _baseLoaiBaiVietRepository.GetByIdAsync((int)request.LoaiBaiVietID);
                if (loaiBaiViet == null)
                {
                    return new ResponseObject<DataResponseChuDe>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại bài viết",
                        Data = null
                    };
                }

                var chuDe = new ChuDe
                {
                    TenChuDe = request.TenChuDe,
                    NoiDung = request.NoiDung,
                    LoaiBaiVietID = request.LoaiBaiVietID,
                };

                chuDe = await _baseChuDeRepository.CreateAsync(chuDe);

                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo chủ đề thành công",
                    Data = _chuDeConverter.EntityToDTO(chuDe)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }

        public async Task<PageResult<DataResponseChuDe>> GetAlls(int pageSize, int pageNumber)
        {
            var chuDes = await _baseChuDeRepository.GetAllAsync().Result.ToListAsync();
            var query = chuDes.Select(x => _chuDeConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseChuDe>> GetChuDeById(int chuDeId)
        {
            var chuDe = await _baseChuDeRepository.GetByIdAsync(chuDeId);
            if (chuDe == null)
            {
                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Không tìm thấy chủ đề",
                    Data = null
                };
            }

            return new ResponseObject<DataResponseChuDe>
            {
                Status = StatusCodes.Status200OK,
                Message = "Tìm thấy chủ đề",
                Data = _chuDeConverter.EntityToDTO(chuDe)
            };
        }

        public async Task<ResponseObject<DataResponseChuDe>> UpdateChuDe(int topicId, Request_EditChuDe request)
        {
            try
            {
                var chuDe = await _baseChuDeRepository.GetByIdAsync(topicId);
                if (chuDe == null)
                {
                    return new ResponseObject<DataResponseChuDe>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy chủ đề",
                        Data = null
                    };
                }
                var loaiBaiViet = await _baseLoaiBaiVietRepository.GetByIdAsync(request.LoaiBaiVietID);
                if (loaiBaiViet == null)
                {
                    return new ResponseObject<DataResponseChuDe>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm loại bài viết",
                        Data = null
                    };
                }

                chuDe.TenChuDe = request.TenChuDe;
                chuDe.NoiDung = request.NoiDung;
                chuDe.LoaiBaiVietID = request.LoaiBaiVietID;

                chuDe = await _baseChuDeRepository.UpdateAsync(chuDe);
                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật chủ đề thành công",
                    Data = _chuDeConverter.EntityToDTO(chuDe)
                };
            }
            catch (Exception e)
            {

                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Error : " + e.Message,
                    Data = null
                };
            }
        }
    }
}
