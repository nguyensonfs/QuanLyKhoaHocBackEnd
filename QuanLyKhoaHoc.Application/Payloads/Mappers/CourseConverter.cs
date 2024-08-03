using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataCourse;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class CourseConverter
    {
        public DataResponseCourse EntityToDTO(KhoaHoc khoaHoc)
        {
            return new DataResponseCourse
            {
                KhoaHocID = khoaHoc.KhoaHocID,
                TenKhoaHoc = khoaHoc.TenKhoaHoc,
                GioiThieu = khoaHoc.GioiThieu,
                NoiDung = khoaHoc.NoiDung,
                HocPhi = khoaHoc.HocPhi,
                SoHocVien = khoaHoc.SoHocVien,
                SoLuongMon = khoaHoc.SoLuongMon,
                ThoiGianHoc = khoaHoc.ThoiGianHoc,
                HinhAnh = khoaHoc.HinhAnh,
                LoaiKhoaHocID = khoaHoc.LoaiKhoaHocID
            };
        }
    }
}
