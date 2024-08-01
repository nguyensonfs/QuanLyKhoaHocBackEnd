namespace QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataRegistration
{
    public class DataResponeRegistration
    {
        public int DangKyHocID { get; set; }

        public int KhoaHocID { get; set; }

        public int HocVienID { get; set; }

        public DateTime NgayDangKy { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public int TinhTrangHocID { get; set; }

        public int TaiKhoanID { get; set; }
    }
}
