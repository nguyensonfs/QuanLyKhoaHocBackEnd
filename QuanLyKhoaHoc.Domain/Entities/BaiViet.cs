using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class BaiViet
    {
        [Key]
        public int BaiVietID { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TenBaiViet { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string TenTacGia { get; set; }

        [MaybeNull]
        public string NoiDung { get; set; }

        [MaxLength(1000)]
        [MaybeNull]
        public string NoiDungNgan { get; set; }

        [MaybeNull]
        public DateTime ThoiGianTao { get; set; }

        [MaybeNull]
        public string HinhAnh { get; set; }

        [MaybeNull]
        public int ChuDeID { get; set; }


        public virtual ChuDe? ChuDe { get; set; }

        [MaybeNull]
        public int TaiKhoanID { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }
    }
}
