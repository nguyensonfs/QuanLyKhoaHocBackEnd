using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Application.Handle.HandlePagination;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataUsers;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class AccountService : IAccountService
    {

        private readonly IBaseRepository<TaiKhoan> _baseTaiKhoanRepository;
        private readonly IBaseRepository<QuyenHan> _baseQuyenHanRepository;
        private readonly AccountConverter _converter;

        public AccountService(AccountConverter converter,
                              IBaseRepository<TaiKhoan> baseTaiKhoanRepository,
                              IBaseRepository<QuyenHan> baseQuyenHanRepository)
        {


            _baseTaiKhoanRepository = baseTaiKhoanRepository;
            _baseQuyenHanRepository = baseQuyenHanRepository;
            _converter = converter;
        }

        public async Task<ResponseObject<DataResponseUser>> AddAccount(Request_CreateAccount request)
        {
            try
            {
                var role = await _baseQuyenHanRepository.GetByIdAsync(request.QuyenHanID);
                if (role == null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy role",
                        Data = null
                    };
                }

                var acc = new TaiKhoan
                {
                    TenDangNhap = request.TenDangNhap,
                    TenNguoiDung = request.TenNguoiDung,
                    MatKhau = request.MatKhau,
                    QuyenHanID = request.QuyenHanID,
                };

                acc = await _baseTaiKhoanRepository.CreateAsync(acc);

                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo tài khoản thành công",
                    Data = _converter.EntityToDTO(acc)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }

        }

        public async Task<string> Delete(int accountId)
        {
            var acc = await _baseTaiKhoanRepository.GetByIdAsync(accountId);
            if (acc == null)
            {
                return "không tìm thấy tài khoản đó";
            }
            await _baseTaiKhoanRepository.DeleteAsync(accountId);
            return "Xoá thành công";
        }

        public async Task<PageResult<DataResponseUser>> GetAlls(int pageSize, int pageNumber)
        {
            var accs = await _baseTaiKhoanRepository.GetAllAsync().Result.ToListAsync();
            var query = accs.Select(x => _converter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }

        public async Task<ResponseObject<DataResponseUser>> GetAccountbyName(string keyword)
        {
            var acc = await _baseTaiKhoanRepository.GetAsync(x => x.TenNguoiDung.ToLower().Contains(keyword.ToLower()));
            if (acc == null)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Không tìm thấy tài khoản",
                    Data = null
                };
            }

            return new ResponseObject<DataResponseUser>
            {
                Status = StatusCodes.Status200OK,
                Message = "Đã tìm thấy tài khoản",
                Data = _converter.EntityToDTO(acc)
            };
        }

        public async Task<PageResult<DataResponseUser>> SearchPagedAccountbyName(string keyword, int pageNumber, int pageSize)
        {
            var query = await _baseTaiKhoanRepository.GetAllAsync(bv => bv.TenNguoiDung.ToLower().Contains(keyword.ToLower()));
            var pagedData = Pagination.GetPagedData(query, pageSize, pageNumber);
            var convertedItems = pagedData.Data.Select(x => _converter.EntityToDTO(x)).AsQueryable();

            return new PageResult<DataResponseUser>(convertedItems, pagedData.TotalItems, pagedData.TotalPages, pageNumber, pageSize);
        }

        public async Task<ResponseObject<DataResponseUser>> UpdateAccount(Request_UpdateAccount request)
        {
            try
            {

                var account = await _baseTaiKhoanRepository.GetByIdAsync(request.TaiKhoanID);
                if (account == null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản",
                        Data = null
                    };
                }
                var role = await _baseQuyenHanRepository.GetByIdAsync(request.QuyenHanID);
                if (role == null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy role",
                        Data = null
                    };
                }
                account.TenDangNhap = request.TenDangNhap;
                account.TenNguoiDung = request.TenNguoiDung;
                account.MatKhau = request.MatKhau;
                account.QuyenHanID = request.QuyenHanID;


                account = await _baseTaiKhoanRepository.UpdateAsync(account);
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật tài khoản thành công",
                    Data = _converter.EntityToDTO(account)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }

        }

    }
}
