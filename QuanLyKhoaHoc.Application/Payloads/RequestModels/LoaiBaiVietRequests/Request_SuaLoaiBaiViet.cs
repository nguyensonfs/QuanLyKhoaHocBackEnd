using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiBaiVietRequests
{
    public class Request_SuaLoaiBaiViet
    {
        public int LoaiBaiVietID { get; set; }

        [Required(ErrorMessage = "TenLoaiBaiViet là bắt buộc")]
        public string TenLoaiBaiViet { get; set; } = string.Empty;
    }
}
