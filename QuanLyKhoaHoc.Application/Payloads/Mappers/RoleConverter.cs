using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataQuyenHan;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class RoleConverter
    {
        public RoleConverter() { }
        public DataResponseQuyenHan EntityToDTO(QuyenHan quyenHan)
        {
            return new DataResponseQuyenHan
            {
                Id = quyenHan.QuyenHanID,
                TenQuyenHan = quyenHan.TenQuyenHan
            };
        }
    }
}
