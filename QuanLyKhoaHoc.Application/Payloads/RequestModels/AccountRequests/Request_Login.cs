using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests
{
    public class Request_Login
    {
        [Required]
        public string TenDangNhap { get; set; } = string.Empty;

        [Required]
        public string MatKhau { get; set; } = string.Empty;
    }
}
