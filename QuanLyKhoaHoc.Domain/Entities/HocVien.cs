using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class HocVien
    {
        [Key]
        public int HocVienID { get; set; }

        public string? HinhAnh { get; set; }

        [MaxLength(50)]
        public string? HoTen { get; set; }

        public DateTime? NgaySinh { get; set; }

        [MaxLength(11)]
        [Column(TypeName = "varchar")]
        public string? SoDienThoai { get; set; }

        [MaxLength(40)]
        [Column(TypeName = "varchar")]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? TinhThanh { get; set; }

        [MaxLength(50)]
        public string? QuanHuyen { get; set; }

        [MaxLength(50)]
        public string? PhuongXa { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string? SoNha { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; } 
    }
}
