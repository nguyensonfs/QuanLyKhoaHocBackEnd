using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiBaiViet;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class LoaiBaiVietService : ILoaiBaiVietService
    {
        private readonly IBaseRepository<LoaiBaiViet> _baseLoaiBaiVietRepository;
        private readonly LoaiBaiVietConverter _converter;

        public LoaiBaiVietService(IBaseRepository<LoaiBaiViet> baseLoaiBaiVietRepository, LoaiBaiVietConverter converter)
        {
            _baseLoaiBaiVietRepository = baseLoaiBaiVietRepository;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseLoaiBaiViet>> CapNhatThongTinLoaiBaiViet(int typeofArticleId, Request_SuaLoaiBaiViet request)
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
                    Message = "Cập nhật loại khoá học thành công",
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

        public async Task<IQueryable<DataResponseLoaiBaiViet>> GetAllLoaiBaiViets()
        {
            var loaiBaiViets = await _baseLoaiBaiVietRepository.GetAllAsync().Result.ToListAsync();
            var dtoList = loaiBaiViets.Select(x => _converter.EntityToDTO(x)).AsQueryable();
            return dtoList;
        }

        public async Task<ResponseObject<DataResponseLoaiBaiViet>> ThemLoaiBaiViet(Request_ThemLoaiBaiViet request)
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

        public async Task<string> XoaLoaiBaiViet(int loaiBaiVietId)
        {
            var loaiBaiViet = await _baseLoaiBaiVietRepository.GetByIdAsync(loaiBaiVietId);
            if (loaiBaiViet == null)
            {
                return "không tìm thấy loại bài viết";
            }
            await _baseLoaiBaiVietRepository.DeleteAsync(loaiBaiVietId);
            return "Xoá thành công";
        }
    }
}
