using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class ChuDe
    {
        [Key]
        public int ChuDeID { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TenChuDe { get; set; }

        [MaybeNull]
        public string NoiDung {  get; set; }

        [MaybeNull]
        public int LoaiBaiVietID { get; set; }
        public virtual LoaiBaiViet? LoaiBaiViet { get; set; }

        public virtual ICollection<BaiViet>? BaiViets { get; set; }
    }
}
