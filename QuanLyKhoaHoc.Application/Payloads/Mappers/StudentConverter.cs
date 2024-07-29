using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudent;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class StudentConverter
    {
        public DataResponseStudent EntityToDTO(HocVien hocVien)
        {
            return new DataResponseStudent
            {
                HinhAnh = hocVien.HinhAnh,
                Email = hocVien.Email,
                HoTen = hocVien.HoTen,
                NgaySinh = hocVien.NgaySinh,
                QuanHuyen = hocVien.QuanHuyen,
                PhuongXa = hocVien.PhuongXa,
                TinhThanh = hocVien.TinhThanh,
                SoDienThoai = hocVien.SoDienThoai,
                SoNha = hocVien.SoNha,
                Id = hocVien.HocVienID
            };
        }
    }
}
