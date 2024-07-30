using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class StudentStatusConverter
    {
        public DataResponseStudentStatus EntityToDTO(TinhTrangHoc tinhTrangHoc)
        {
            return new DataResponseStudentStatus
            {
                Id = tinhTrangHoc.TinhTrangHocID,
                TenTinhTrang = tinhTrangHoc.TenTinhTrang
            };
        }
    }
}
