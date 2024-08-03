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

        private readonly IBaseRepository<TaiKhoan> _baseAccountRepository;
        private readonly IBaseRepository<QuyenHan> _baseRoleRepository;
        private readonly AccountConverter _accountConverter;

        public AccountService(AccountConverter accountConverter,
                              IBaseRepository<TaiKhoan> baseAccountRepository,
                              IBaseRepository<QuyenHan> baseRoleRepository)
        {


            _baseAccountRepository = baseAccountRepository;
            _baseRoleRepository = baseRoleRepository;
            _accountConverter = accountConverter;
        }

        public async Task<PageResult<DataResponseUser>> GetAlls(int pageSize, int pageNumber)
        {
            var accs = await _baseAccountRepository.GetAllAsync().Result.ToListAsync();
            var query = accs.Select(x => _accountConverter.EntityToDTO(x)).AsQueryable();
            var result = Pagination.GetPagedData(query, pageSize, pageNumber);
            return result;
        }
        public async Task<PageResult<DataResponseUser>> SearchPagedAccountbyName(string keyword, int pageNumber, int pageSize)
        {
            var query = await _baseAccountRepository.GetAllAsync(bv => bv.TenNguoiDung.ToLower().Contains(keyword.ToLower()));
            var pagedData = Pagination.GetPagedData(query, pageSize, pageNumber);
            var convertedItems = pagedData.Data.Select(x => _accountConverter.EntityToDTO(x)).AsQueryable();

            return new PageResult<DataResponseUser>(convertedItems, pagedData.TotalItems, pagedData.TotalPages, pageNumber, pageSize);
        }
        public async Task<ResponseObject<DataResponseUser>> GetAccountbyName(string keyword)
        {
            var acc = await _baseAccountRepository.GetAsync(x => x.TenNguoiDung.ToLower().Contains(keyword.ToLower()));
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
                Data = _accountConverter.EntityToDTO(acc)
            };
        }
        public async Task<ResponseObject<DataResponseUser>> CreateAccount(Request_CreateAccount request)
        {
            try
            {
                var role = await _baseRoleRepository.GetByIdAsync(request.QuyenHanID);
                if (role == null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy quyền",
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

                acc = await _baseAccountRepository.CreateAsync(acc);

                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo tài khoản thành công",
                    Data = _accountConverter.EntityToDTO(acc)
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
        public async Task<ResponseObject<DataResponseUser>> UpdateAccount(int accountId, Request_UpdateAccount request)
        {
            try
            {

                var account = await _baseAccountRepository.GetByIdAsync(accountId);
                if (account == null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản",
                        Data = null
                    };
                }
                var role = await _baseRoleRepository.GetByIdAsync(request.QuyenHanID);
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


                account = await _baseAccountRepository.UpdateAsync(account);
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật tài khoản thành công",
                    Data = _accountConverter.EntityToDTO(account)
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
        public async Task<string> DeleteAccount(int accountId)
        {
            var acc = await _baseAccountRepository.GetByIdAsync(accountId);
            if (acc == null)
            {
                return "không tìm thấy tài khoản đó";
            }
            await _baseAccountRepository.DeleteAsync(accountId);
            return "Xoá thành công";
        }
    }
}
