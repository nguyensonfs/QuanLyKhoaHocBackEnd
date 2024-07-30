using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class LoaiBaiViet
    {
        [Key]
        public int LoaiBaiVietID { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TenLoai { get; set; } 
        
        public virtual ICollection<ChuDe>? ChuDes { get; set; }
    }
}
