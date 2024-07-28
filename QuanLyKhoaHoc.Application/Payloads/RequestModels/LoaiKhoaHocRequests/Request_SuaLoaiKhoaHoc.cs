using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.LoaiKhoaHocRequests
{
    public class Request_SuaLoaiKhoaHoc
    {
        public int LoaiKhoaHocID { get; set; }

        [Required(ErrorMessage = "TenLoaiKhoaHoc là bắt buộc")]
        public string TenLoaiKhoaHoc { get; set; } = string.Empty;
    }
}
