using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class LearningStatusConverter
    {
        public DataResponseLearningStatus EntityToDTO(TinhTrangHoc tinhTrangHoc)
        {
            return new DataResponseLearningStatus
            {
                Id = tinhTrangHoc.TinhTrangHocID,
                TenTinhTrang = tinhTrangHoc.TenTinhTrang
            };
        }
    }
}
