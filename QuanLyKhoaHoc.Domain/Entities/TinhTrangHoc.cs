using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class TinhTrangHoc
    {
        [Key]
        public int TinhTrangHocID { get; set; }

        [MaxLength(40)]
        [MaybeNull]
        public string TenTinhTrang { get; set; }

        public virtual ICollection<DangKyHoc>? DangKyHocs { get; set; }
    }
}
