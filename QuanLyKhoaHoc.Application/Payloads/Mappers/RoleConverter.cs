using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataRole;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class RoleConverter
    {
        public RoleConverter() { }
        public DataResponseRole EntityToDTO(QuyenHan quyenHan)
        {
            return new DataResponseRole
            {
                Id = quyenHan.QuyenHanID,
                TenQuyenHan = quyenHan.TenQuyenHan
            };
        }
    }
}
