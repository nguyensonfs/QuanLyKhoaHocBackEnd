using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataKhoaHoc;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class KhoaHocConverter
    {
        public DataResponseKhoaHoc EntityToDTO(KhoaHoc khoaHoc)
        {
            return new DataResponseKhoaHoc
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
