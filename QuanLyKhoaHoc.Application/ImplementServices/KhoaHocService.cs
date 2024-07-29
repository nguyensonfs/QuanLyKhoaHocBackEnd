using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandleImage;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.KhoaHocRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly IBaseRepository<KhoaHoc> _baseKhoaHocRepository;
        private readonly IBaseRepository<LoaiKhoaHoc> _baseLoaiKhoaHocRepository;
        private readonly KhoaHocConverter _converter;

        public KhoaHocService(IBaseRepository<KhoaHoc> baseKhoaHocRepository, KhoaHocConverter converter, IBaseRepository<LoaiKhoaHoc> baseLoaiKhoaHocRepository)
        {
            _baseKhoaHocRepository = baseKhoaHocRepository;
            _baseLoaiKhoaHocRepository = baseLoaiKhoaHocRepository;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> CapNhatThongTinKhoaHoc(Request_SuaKhoaHoc request)
        {
            try
            {
                var khoaHoc = await _baseKhoaHocRepository.GetByIdAsync(request.KhoaHocID);
                var loaiKhoaHoc = await _baseLoaiKhoaHocRepository.GetByIdAsync((int)request.LoaiKhoaHocID);
                if (khoaHoc == null)
                {
                    return new ResponseObject<DataResponseKhoaHoc>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy khoá học",
                        Data = null
                    };
                }
                if (loaiKhoaHoc == null)
                {
                    return new ResponseObject<DataResponseKhoaHoc>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại khoá học",
                        Data = null
                    };
                }
                khoaHoc.GioiThieu = request.GioiThieu;
                khoaHoc.HinhAnh = await HandleUploadImage.Upfile(request.HinhAnh);
                khoaHoc.HocPhi = request.HocPhi;
                khoaHoc.LoaiKhoaHocID = request.LoaiKhoaHocID;
                khoaHoc.TenKhoaHoc = request.TenKhoaHoc;
                khoaHoc.NoiDung = request.NoiDung;
                khoaHoc.SoLuongMon = request.SoLuongMon;

                khoaHoc = await _baseKhoaHocRepository.UpdateAsync(khoaHoc);
                return new ResponseObject<DataResponseKhoaHoc>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật khoá học thành công",
                    Data = _converter.EntityToDTO(khoaHoc)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseKhoaHoc>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }

        //public async Task<IQueryable<DataResponseKhoaHoc>> GetAllKhoaHocs()
        //{
        //    var khoaHocs = await _baseKhoaHocRepository.GetAllAsync().Result.ToListAsync();
        //    var dtoList = khoaHocs.Select(x => _converter.EntityToDTO(x)).AsQueryable();
        //    return dtoList;
        //}

        public async Task<PageResult<DataResponseKhoaHoc>> GetAlls(int pageSize, int pageNumber)
        {
            var loaiBaiViets = await _baseKhoaHocRepository.GetAllAsync().Result.ToListAsync();
            var query = loaiBaiViets.Select(x => _converter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> GetKhoaHocByName(string tenKhoaHoc)
        {
            var khoaHoc = await _baseKhoaHocRepository.GetAsync(x => x.TenKhoaHoc.ToLower().Contains(tenKhoaHoc.ToLower()));
            if (khoaHoc == null)
            {
                return new ResponseObject<DataResponseKhoaHoc>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Không tìm thấy khoá học",
                    Data = null
                };
            }

            return new ResponseObject<DataResponseKhoaHoc>
            {
                Status = StatusCodes.Status200OK,
                Message = "Đã tìm thấy khoá học",
                Data = _converter.EntityToDTO(khoaHoc)
            };

        }

        public async Task<PageResult<DataResponseKhoaHoc>> SearchPagedKhoaHocsByName(string tenKhoaHoc, int pageNumber, int pageSize)
        {
            var query = await _baseKhoaHocRepository.GetAllAsync(kh => kh.TenKhoaHoc.ToLower().Contains(tenKhoaHoc.ToLower()));
            var pagedData = Pagination.GetPagedData(query, pageSize, pageNumber);
            var convertedItems = pagedData.Data.Select(khoaHoc => _converter.EntityToDTO(khoaHoc)).AsQueryable();

            return new PageResult<DataResponseKhoaHoc>(convertedItems, pagedData.TotalItems, pagedData.TotalPages, pageNumber, pageSize);
        }

        public async Task<ResponseObject<DataResponseKhoaHoc>> ThemKhoaHoc(Request_ThemKhoaHoc request)
        {
            try
            {
                var loaiKhoaHoc = await _baseLoaiKhoaHocRepository.GetByIdAsync((int)request.LoaiKhoaHocID);
                if (loaiKhoaHoc == null)
                {
                    return new ResponseObject<DataResponseKhoaHoc>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy khoá học",
                        Data = null
                    };
                }

                var khoaHoc = new KhoaHoc
                {
                    TenKhoaHoc = request.TenKhoaHoc,
                    HinhAnh = await HandleUploadImage.Upfile(request.HinhAnh),
                    GioiThieu = request.GioiThieu,
                    HocPhi = request.HocPhi,
                    NoiDung = request.NoiDung,
                    SoLuongMon = request.SoLuongMon,
                    SoHocVien = 0,
                    LoaiKhoaHocID = request.LoaiKhoaHocID,
                };

                khoaHoc = await _baseKhoaHocRepository.CreateAsync(khoaHoc);

                return new ResponseObject<DataResponseKhoaHoc>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo khoá học thành công",
                    Data = _converter.EntityToDTO(khoaHoc)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseKhoaHoc>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }

        public async Task<string> XoaKhoaHoc(int khoaHocID)
        {
            var khoaHoc = await _baseKhoaHocRepository.GetByIdAsync(khoaHocID);
            if (khoaHoc == null)
            {
                return "không tìm thấy quyền hạn đó";
            }
            await _baseKhoaHocRepository.DeleteAsync(khoaHocID);
            return "Xoá thành công";
        }
    }
}
