using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class HocVien
    {
        [Key]
        public int HocVienID { get; set; }

        [MaybeNull]
        public string HinhAnh { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string HoTen { get; set; }

        [MaybeNull]
        public DateTime NgaySinh { get; set; }

        [MaxLength(11)]
        [Column(TypeName = "varchar")]
        [MaybeNull]
        public string SoDienThoai { get; set; }

        [MaxLength(40)]
        [Column(TypeName = "varchar")]
        [MaybeNull]
        public string Email { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TinhThanh { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string QuanHuyen { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string PhuongXa { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        [MaybeNull]
        public string SoNha { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; } 
    }
}
