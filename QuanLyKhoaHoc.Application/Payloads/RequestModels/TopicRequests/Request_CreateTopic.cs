using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.TopicRequests
{
    public class Request_CreateTopic
    {
        [Required]
        public string TenChuDe { get; set; } = string.Empty;

        [Required]
        public string NoiDung { get; set; } = string.Empty;

        [Required]
        public int LoaiBaiVietID { get; set; }
    }
}
