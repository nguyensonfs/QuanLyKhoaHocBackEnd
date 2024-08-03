using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.TypeOfArticleRequests
{
    public class Request_CreateTypeOfArticle
    {
        [Required(ErrorMessage = "TenLoaiBaiViet là bắt buộc")]
        public string TenLoaiBaiViet { get; set; } = string.Empty;
    }
}
