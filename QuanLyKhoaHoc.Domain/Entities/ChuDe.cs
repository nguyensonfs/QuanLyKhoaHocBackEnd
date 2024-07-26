using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class ChuDe
    {
        [Key]
        public int ChuDeID { get; set; }

        [MaxLength(50)]
        public string? TenChuDe { get; set; }

        public string? NoiDung {  get; set; }

        public int? LoaiBaiVietID { get; set; }
        public virtual LoaiBaiViet? LoaiBaiViet { get; set; }

        public virtual ICollection<BaiViet>? BaiViets { get; set; }
    }
}
