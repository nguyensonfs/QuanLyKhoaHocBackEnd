using System.Diagnostics.CodeAnalysis;

namespace QuanLyKhoaHoc.Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }

        [MaybeNull]
        public string Token { get; set; }

        [MaybeNull]
        public int TaiKhoanId { get; set; }

        public virtual TaiKhoan? TaiKhoan { get; set; }

        public DateTime ExpiryTime { get; set; }
    }
}
