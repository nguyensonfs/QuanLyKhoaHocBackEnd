using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class DangKyHoc
    {
        [Key]
        public int DangKyHocID { get; set; }

        [MaybeNull]
        public int KhoaHocID { get; set; }
        public virtual KhoaHoc? KhoaHoc { get; set; }

        [MaybeNull]
        public int HocVienID { get; set; }
        public virtual HocVien? HocVien { get; set; }

        [MaybeNull]
        public DateTime NgayDangKy { get; set; }

        [MaybeNull]
        public DateTime NgayBatDau { get; set; }

        [MaybeNull]
        public DateTime NgayKetThuc { get; set; }

        [MaybeNull]
        public int TinhTrangHocID { get; set; }
        public virtual TinhTrangHoc? TinhTrangHoc { get; set; }

        [MaybeNull]
        public int TaiKhoanID { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }

    }
}
