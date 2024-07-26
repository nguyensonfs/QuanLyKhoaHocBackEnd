using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class LoaiBaiViet
    {
        [Key]
        public int LoaiBaiVietID { get; set; }

        [MaxLength(50)]
        public string? TenLoai { get; set; } 
        
        public virtual ICollection<ChuDe>? ChuDes { get; set; }
    }
}
