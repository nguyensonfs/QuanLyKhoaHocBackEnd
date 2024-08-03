using Microsoft.AspNetCore.Http;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.CourseRequests
{
    public class Request_UpdateCourse
    {

        public string TenKhoaHoc { get; set; }

        public int ThoiGianHoc { get; set; }

        public string GioiThieu { get; set; }

        public string NoiDung { get; set; }

        public float HocPhi { get; set; }

        public int SoLuongMon { get; set; }

        public IFormFile HinhAnh { get; set; }

        public int LoaiKhoaHocID { get; set; }
    }
}
