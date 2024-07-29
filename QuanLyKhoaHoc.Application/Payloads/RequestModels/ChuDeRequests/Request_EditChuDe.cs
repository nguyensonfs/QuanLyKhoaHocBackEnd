using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests
{
    public class Request_EditChuDe
    {
        public int ChuDeID { get; set; }

        [Required]
        public string TenChuDe { get; set; } = string.Empty;

        [Required]
        public string NoiDung { get; set; } = string.Empty;

        [Required]
        public int LoaiBaiVietID { get; set; }
    }
}
