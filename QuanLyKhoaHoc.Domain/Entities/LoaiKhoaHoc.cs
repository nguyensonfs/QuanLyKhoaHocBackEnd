using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class LoaiKhoaHoc
    {
        [Key]
        public int LoaiKhoaHocID { get; set; }

        [MaxLength(30)]
        [MaybeNull]
        public string TenLoai { get; set; }

        public virtual ICollection<KhoaHoc>? KhoaHocs { get; set; }
    }
}
