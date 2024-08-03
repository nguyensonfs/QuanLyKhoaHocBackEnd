using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandleImage;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ArticleRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataArticles;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class ArticleService : IArticleService
    {
        private readonly IBaseRepository<BaiViet> _baseArticleRepository;
        private readonly IBaseRepository<TaiKhoan> _baseAccountRepository;
        private readonly IBaseRepository<ChuDe> _baseTopicRepository;
        private readonly ArticleConverter _articleConverter;

        public ArticleService(IBaseRepository<BaiViet> baseArticleRepository,
                              ArticleConverter articleConverter,
                              IBaseRepository<TaiKhoan> baseAccountRepository,
                              IBaseRepository<ChuDe> baseTopicRepository)
        {
            _baseArticleRepository = baseArticleRepository;
            _articleConverter = articleConverter;
            _baseAccountRepository = baseAccountRepository;
            _baseTopicRepository = baseTopicRepository;
        }

        public async Task<PageResult<DataResponseArticle>> GetAllArticles(int pageSize, int pageNumber)
        {
            var articles = await _baseArticleRepository.GetAllAsync().Result.ToListAsync();
            var query = articles.Select(x => _articleConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }
        public async Task<PageResult<DataResponseArticle>> SearchPagedArticlebyName(string keyword, int pageNumber, int pageSize)
        {
            var query = await _baseArticleRepository.GetAllAsync(bv => bv.TenBaiViet.ToLower().Contains(keyword.ToLower()));
            var pagedData = Pagination.GetPagedData(query, pageSize, pageNumber);
            var convertedItems = pagedData.Data.Select(x => _articleConverter.EntityToDTO(x)).AsQueryable();

            return new PageResult<DataResponseArticle>(convertedItems, pagedData.TotalItems, pagedData.TotalPages, pageNumber, pageSize);
        }
        public async Task<ResponseObject<DataResponseArticle>> GetArticlebyName(string keyword)
        {
            var article = await _baseArticleRepository.GetAsync(x => x.TenBaiViet.ToLower().Contains(keyword.ToLower()));
            if (article == null)
            {
                return new ResponseObject<DataResponseArticle>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Không tìm thấy bài viết",
                    Data = null
                };
            }

            return new ResponseObject<DataResponseArticle>
            {
                Status = StatusCodes.Status200OK,
                Message = "Đã tìm thấy bài viết",
                Data = _articleConverter.EntityToDTO(article)
            };
        }
        public async Task<ResponseObject<DataResponseArticle>> CreateArticle(Request_CreateArticle request)
        {
            try
            {
                var account = await _baseAccountRepository.GetByIdAsync(request.TaiKhoanID);
                if (account == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản",
                        Data = null
                    };
                }
                var topic = await _baseTopicRepository.GetByIdAsync(request.ChuDeID);
                if (topic == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy chủ đề",
                        Data = null
                    };
                }

                var article = new BaiViet
                {
                    TenBaiViet = request.TenBaiViet,
                    HinhAnh = await HandleUploadImage.Upfile(request.HinhAnh),
                    NoiDungNgan = request.NoiDungNgan,
                    TenTacGia = request.TenTacGia,
                    NoiDung = request.NoiDung,
                    ThoiGianTao = DateTime.Now,
                    ChuDeID = request.ChuDeID,
                    TaiKhoanID = request.TaiKhoanID,
                };

                article = await _baseArticleRepository.CreateAsync(article);

                return new ResponseObject<DataResponseArticle>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo bài viết thành công",
                    Data = _articleConverter.EntityToDTO(article)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseArticle>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }

        }
        public async Task<ResponseObject<DataResponseArticle>> UpdateArticle(int articleId, Request_UpdateArtice request)
        {
            try
            {
                var article = await _baseArticleRepository.GetByIdAsync(articleId);
                if (article == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy bài viết",
                        Data = null
                    };
                }
                var account = await _baseAccountRepository.GetByIdAsync(request.TaiKhoanID);
                if (account == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản",
                        Data = null
                    };
                }
                var topic = await _baseTopicRepository.GetByIdAsync(request.ChuDeID);
                if (topic == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy chủ đề",
                        Data = null
                    };
                }
                article.TenTacGia = request.TenTacGia;
                article.HinhAnh = await HandleUploadImage.Upfile(request.HinhAnh);
                article.ChuDeID = request.ChuDeID;
                article.NoiDungNgan = request.NoiDungNgan;
                article.NoiDung = request.NoiDung;
                article.TaiKhoanID = request.TaiKhoanID;
                article.ThoiGianTao = DateTime.Now;

                article = await _baseArticleRepository.UpdateAsync(article);
                return new ResponseObject<DataResponseArticle>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật khoá học thành công",
                    Data = _articleConverter.EntityToDTO(article)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseArticle>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }

        }
        public async Task<string> DeleteArticle(int articleId)
        {
            var article = await _baseArticleRepository.GetByIdAsync(articleId);
            if (article == null)
            {
                return "Không tìm thấy bài viết đó";
            }
            await _baseArticleRepository.DeleteAsync(articleId);
            return "Xoá thành công";
        }
    }
}
