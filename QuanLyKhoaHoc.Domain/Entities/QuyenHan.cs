using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class QuyenHan
    {
        [Key]
        public int QuyenHanID { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TenQuyenHan { get; set; }

        public virtual ICollection<TaiKhoan>? TaiKhoans { get; set; }
    }
}
