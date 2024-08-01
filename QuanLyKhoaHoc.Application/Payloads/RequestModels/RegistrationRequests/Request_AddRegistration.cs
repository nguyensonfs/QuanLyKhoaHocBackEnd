using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.RegistrationRequests
{
    public class Request_AddRegistration
    {

        public int KhoaHocID { get; set; }

        public int HocVienID { get; set; }

        public int TinhTrangHocID { get; set; }

        public int TaiKhoanID { get; set; }

        public Request_AddStudent Student { get; set; }
    }
}
