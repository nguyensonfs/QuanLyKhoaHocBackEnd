using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class TinhTrangHoc
    {
        [Key]
        public int TinhTrangHocID { get; set; }

        [MaxLength(40)]
        public string? TenTinhTrang { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; }
    }
}
