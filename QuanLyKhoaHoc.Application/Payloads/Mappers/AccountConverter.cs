using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataUsers;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class AccountConverter
    {
        public DataResponseUser EntityToDTO(TaiKhoan taiKhoan)
        {
            return new DataResponseUser
            {
                TaiKhoanID = taiKhoan.TaiKhoanID,
                TenNguoiDung = taiKhoan.TenNguoiDung,
                MatKhau = taiKhoan.MatKhau,
                QuyenHanID = taiKhoan.QuyenHanID,
                TenDangNhap = taiKhoan.TenDangNhap
            };
        }
    }
}
