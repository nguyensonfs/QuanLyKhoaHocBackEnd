using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTypeOfArticle;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class TypeOfArticleService : ITypeOfArticleService
    {
        private readonly IBaseRepository<LoaiBaiViet> _baseTypeOfArticleRepository;
        private readonly TypeOfArticleConverter _typeOfArticleConverter;

        public TypeOfArticleService(IBaseRepository<LoaiBaiViet> baseTypeOfArticleRepository,
                                    TypeOfArticleConverter typeOfArticleConverter)
        {
            _baseTypeOfArticleRepository = baseTypeOfArticleRepository;
            _typeOfArticleConverter = typeOfArticleConverter;
        }
        public async Task<PageResult<DataResponseTypeOfArticle>> GetAllTypeOfArticles(int pageSize, int pageNumber)
        {
            var typeOfArticles = await _baseTypeOfArticleRepository.GetAllAsync().Result.ToListAsync();
            var query = typeOfArticles.Select(x => _typeOfArticleConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }
        public async Task<ResponseObject<DataResponseTypeOfArticle>> CreateTypeOfArticle(Request_CreateTypeOfArticle request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.TenLoaiBaiViet))
                {
                    return new ResponseObject<DataResponseTypeOfArticle>
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

                loaiBaiViet = await _baseTypeOfArticleRepository.CreateAsync(loaiBaiViet);

                return new ResponseObject<DataResponseTypeOfArticle>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo loại bài viết thành công",
                    Data = _typeOfArticleConverter.EntityToDTO(loaiBaiViet)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseTypeOfArticle>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }
        }
        public async Task<ResponseObject<DataResponseTypeOfArticle>> UpdateTypeOfArticle(int typeofArticleId, Request_UpdateTypeOfArticle request)
        {
            try
            {
                var loaiBaiViet = await _baseTypeOfArticleRepository.GetByIdAsync(typeofArticleId);
                if (loaiBaiViet == null)
                {
                    return new ResponseObject<DataResponseTypeOfArticle>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại bài viết",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.TenLoaiBaiViet))
                {
                    return new ResponseObject<DataResponseTypeOfArticle>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                loaiBaiViet.TenLoai = request.TenLoaiBaiViet;
                loaiBaiViet = await _baseTypeOfArticleRepository.UpdateAsync(loaiBaiViet);

                return new ResponseObject<DataResponseTypeOfArticle>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật loại bài viết thành công",
                    Data = _typeOfArticleConverter.EntityToDTO(loaiBaiViet)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseTypeOfArticle>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }
        public async Task<string> DeleteTypeOfArticle(int typeOfArticleId)
        {
            var loaiBaiViet = await _baseTypeOfArticleRepository.GetByIdAsync(typeOfArticleId);
            if (loaiBaiViet == null)
            {
                return "không tìm thấy loại bài viết";
            }
            await _baseTypeOfArticleRepository.DeleteAsync(typeOfArticleId);
            return "Xoá thành công";
        }
    }
}
