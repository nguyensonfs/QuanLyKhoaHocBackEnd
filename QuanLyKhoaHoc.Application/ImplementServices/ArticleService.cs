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
        private readonly IBaseRepository<BaiViet> _baseBaiVietRepository;
        private readonly IBaseRepository<TaiKhoan> _baseTaiKhoanRepository;
        private readonly IBaseRepository<ChuDe> _baseChuDeRepository;
        private readonly ArticleConverter _articleConverter;

        public ArticleService(IBaseRepository<BaiViet> baseBaiVietRepository,
                              ArticleConverter articleConverter,
                              IBaseRepository<TaiKhoan> baseTaiKhoanRepository,
                              IBaseRepository<ChuDe> baseChuDeRepository)
        {
            _baseBaiVietRepository = baseBaiVietRepository;
            _articleConverter = articleConverter;
            _baseTaiKhoanRepository = baseTaiKhoanRepository;
            _baseChuDeRepository = baseChuDeRepository;
        }

        public async Task<ResponseObject<DataResponseArticle>> AddArticle(Request_Create request)
        {
            try
            {
                var account = await _baseTaiKhoanRepository.GetByIdAsync(request.TaiKhoanID);
                if (account == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản",
                        Data = null
                    };
                }
                var chuDe = await _baseChuDeRepository.GetByIdAsync(request.ChuDeID);
                if (chuDe == null)
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

                article = await _baseBaiVietRepository.CreateAsync(article);

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

        public async Task<string> Delete(int baivietId)
        {
            var article = await _baseBaiVietRepository.GetByIdAsync(baivietId);
            if (article == null)
            {
                return "không tìm thấy bài viết đó";
            }
            await _baseBaiVietRepository.DeleteAsync(baivietId);
            return "Xoá thành công";
        }

        public async Task<PageResult<DataResponseArticle>> GetAlls(int pageSize, int pageNumber)
        {
            var articles = await _baseBaiVietRepository.GetAllAsync().Result.ToListAsync();
            var query = articles.Select(x => _articleConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseArticle>> GetArticlebyName(string keyword)
        {
            var article = await _baseBaiVietRepository.GetAsync(x => x.TenBaiViet.ToLower().Contains(keyword.ToLower()));
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

        public async Task<PageResult<DataResponseArticle>> SearchPagedArticlebyName(string keyword, int pageNumber, int pageSize)
        {
            var query = await _baseBaiVietRepository.GetAllAsync(bv => bv.TenBaiViet.ToLower().Contains(keyword.ToLower()));
            var pagedData = Pagination.GetPagedData(query, pageSize, pageNumber);
            var convertedItems = pagedData.Data.Select(x => _articleConverter.EntityToDTO(x)).AsQueryable();

            return new PageResult<DataResponseArticle>(convertedItems, pagedData.TotalItems, pagedData.TotalPages, pageNumber, pageSize);
        }

        public async Task<ResponseObject<DataResponseArticle>> UpdateArticle(int articleId, Request_Update request)
        {
            try
            {
                var article = await _baseBaiVietRepository.GetByIdAsync(articleId);
                if (article == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy bài viết",
                        Data = null
                    };
                }
                var account = await _baseTaiKhoanRepository.GetByIdAsync(request.TaiKhoanID);
                if (account == null)
                {
                    return new ResponseObject<DataResponseArticle>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản",
                        Data = null
                    };
                }
                var chuDe = await _baseChuDeRepository.GetByIdAsync(request.ChuDeID);
                if (chuDe == null)
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

                article = await _baseBaiVietRepository.UpdateAsync(article);
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

    }
}
