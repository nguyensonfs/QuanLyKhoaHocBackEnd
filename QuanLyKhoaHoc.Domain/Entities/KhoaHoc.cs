using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class KhoaHoc
    {
        [Key]
        public int KhoaHocID { get; set; }

        [MaxLength(50)]
        public string? TenKhoaHoc { get; set; }

        public int? ThoiGianHoc { get; set; }

        public string? GioiThieu { get; set; }

        public string? NoiDung { get; set; }

        [Column(TypeName ="float")]
        public float? HocPhi { get; set; }

        public int? SoHocVien { get; set; }

        public int? SoLuongMon { get; set; }

        public string? HinhAnh {  get; set; }

        public int? LoaiKhoaHocID { get; set; }
        public virtual LoaiKhoaHoc? LoaiKhoaHoc { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; }
    }
}
