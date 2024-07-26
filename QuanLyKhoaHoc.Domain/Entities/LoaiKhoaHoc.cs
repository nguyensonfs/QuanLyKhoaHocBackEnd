using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class LoaiKhoaHoc
    {
        [Key]
        public int LoaiKhoaHocID { get; set; }

        [MaxLength(30)]
        public string? TenLoai { get; set; }

        public virtual ICollection<KhoaHoc>? KhoaHocs { get; set; }
    }
}
