using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class DangKyHoc
    {
        [Key]
        public int DangKyHocID { get; set; }

        public int? KhoaHocID { get; set; }
        public virtual KhoaHoc? KhoaHoc { get; set; }

        public int? HocVienID { get; set; }
        public virtual HocVien? HocVien { get; set; }

        public DateTime? NgayDangKy { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public int? TinhTrangHocID { get; set; }
        public virtual TinhTrangHoc? TinhTrangHoc { get; set; }

        public int? TaiKhoanID { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }

    }
}
