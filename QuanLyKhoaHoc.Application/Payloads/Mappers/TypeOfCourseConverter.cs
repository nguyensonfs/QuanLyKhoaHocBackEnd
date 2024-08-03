using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTypeOfCourse;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Infrastructure.DataContexts;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class TypeOfCourseConverter
    {
        public DataResponseTypeOfCourse EntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new DataResponseTypeOfCourse
            {
                Id = loaiKhoaHoc.LoaiKhoaHocID,
                TenLoaiKhoaHoc = loaiKhoaHoc.TenLoai,
            };
        }
    }
}
