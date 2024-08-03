using Microsoft.AspNetCore.Http;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.ArticleRequests
{
    public class Request_CreateArticle
    {
        public string TenBaiViet { get; set; }

        public string TenTacGia { get; set; }

        public string NoiDung { get; set; }

        public string NoiDungNgan { get; set; }

        public IFormFile HinhAnh { get; set; }

        public int ChuDeID { get; set; }

        public int TaiKhoanID { get; set; }

    }
}
