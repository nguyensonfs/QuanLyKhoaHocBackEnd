using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class QuyenHan
    {
        [Key]
        public int QuyenHanID { get; set; }

        [MaxLength(50)]
        public string? TenQuyenHan { get; set; }

        public virtual ICollection<TaiKhoan>? TaiKhoans { get; set; }
    }
}
