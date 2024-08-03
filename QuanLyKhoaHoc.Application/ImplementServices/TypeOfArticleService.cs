using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiBaiViet;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class TypeOfArticleService : ITypeOfArticleService
    {
        private readonly IBaseRepository<LoaiBaiViet> _baseLoaiBaiVietRepository;
        private readonly TypeOfArticleConverter _converter;

        public TypeOfArticleService(IBaseRepository<LoaiBaiViet> baseLoaiBaiVietRepository, TypeOfArticleConverter converter)
        {
            _baseLoaiBaiVietRepository = baseLoaiBaiVietRepository;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseLoaiBaiViet>> UpdateTypeOfArticle(int typeofArticleId, Request_UpdateTypeOfArticle request)
        {
            try
            {
                var loaiBaiViet = await _baseLoaiBaiVietRepository.GetByIdAsync(typeofArticleId);
                if (loaiBaiViet == null)
                {
                    return new ResponseObject<DataResponseLoaiBaiViet>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại bài viết",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.TenLoaiBaiViet))
                {
                    return new ResponseObject<DataResponseLoaiBaiViet>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                loaiBaiViet.TenLoai = request.TenLoaiBaiViet;
                loaiBaiViet = await _baseLoaiBaiVietRepository.UpdateAsync(loaiBaiViet);

                return new ResponseObject<DataResponseLoaiBaiViet>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật loại bài viết thành công",
                    Data = _converter.EntityToDTO(loaiBaiViet)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseLoaiBaiViet>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }

        public async Task<IQueryable<DataResponseLoaiBaiViet>> GetAllTypeOfArticles()
        {
            var loaiBaiViets = await _baseLoaiBaiVietRepository.GetAllAsync().Result.ToListAsync();
            var dtoList = loaiBaiViets.Select(x => _converter.EntityToDTO(x)).AsQueryable();
            return dtoList;
        }

        public async Task<ResponseObject<DataResponseLoaiBaiViet>> CreateTypeOfArticle(Request_CreateTypeOfArticle request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenLoaiBaiViet))
                {
                    return new ResponseObject<DataResponseLoaiBaiViet>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }

                var loaiBaiViet = new LoaiBaiViet
                {
                    TenLoai = request.TenLoaiBaiViet,
                };

                loaiBaiViet = await _baseLoaiBaiVietRepository.CreateAsync(loaiBaiViet);

                return new ResponseObject<DataResponseLoaiBaiViet>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo loại bài viết thành công",
                    Data = _converter.EntityToDTO(loaiBaiViet)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseLoaiBaiViet>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }
        }

        public async Task<string> DeleteTypeOfArticle(int typeOfArticleId)
        {
            var loaiBaiViet = await _baseLoaiBaiVietRepository.GetByIdAsync(typeOfArticleId);
            if (loaiBaiViet == null)
            {
                return "không tìm thấy loại bài viết";
            }
            await _baseLoaiBaiVietRepository.DeleteAsync(typeOfArticleId);
            return "Xoá thành công";
        }
    }
}
