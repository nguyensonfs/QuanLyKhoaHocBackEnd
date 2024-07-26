using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class TaiKhoan
    {
        [Key]
        public int TaiKhoanID { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string? TenNguoiDung { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string? TenDangNhap { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string? MatKhau { get; set; }

        public int? QuyenHanID { get; set; }
        public virtual QuyenHan? QuyenHan { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; }
        public virtual ICollection<BaiViet>? BaiViets { get; set; }
    }
}
