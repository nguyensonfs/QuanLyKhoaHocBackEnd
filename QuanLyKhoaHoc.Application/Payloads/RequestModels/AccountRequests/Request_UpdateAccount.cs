namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.AccountRequests
{
    public class Request_UpdateAccount
    {

        public int TaiKhoanID { get; set; }


        public string TenNguoiDung { get; set; }


        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }


        public int QuyenHanID { get; set; }
    }
}
