using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests
{
    public class Request_ThemLoaiBaiViet
    {
        [Required(ErrorMessage = "TenLoaiBaiViet là bắt buộc")]
        public string TenLoaiBaiViet { get; set; } = string.Empty;
    }
}
