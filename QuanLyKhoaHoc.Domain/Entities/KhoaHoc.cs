using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class KhoaHoc
    {
        [Key]
        public int KhoaHocID { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TenKhoaHoc { get; set; }

        [MaybeNull]
        public int ThoiGianHoc { get; set; }

        [MaybeNull]
        public string GioiThieu { get; set; }

        [MaybeNull]
        public string NoiDung { get; set; }

        [Column(TypeName ="float")]
        [MaybeNull]
        public float HocPhi { get; set; }

        [MaybeNull]
        public int SoHocVien { get; set; }

        [MaybeNull]
        public int SoLuongMon { get; set; }

        [MaybeNull]
        public string HinhAnh {  get; set; }

        [MaybeNull]
        public int LoaiKhoaHocID { get; set; }
        public virtual LoaiKhoaHoc? LoaiKhoaHoc { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; }
    }
}
