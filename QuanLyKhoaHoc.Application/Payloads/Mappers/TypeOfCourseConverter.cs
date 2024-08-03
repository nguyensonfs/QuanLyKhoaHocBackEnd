using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Infrastructure.DataContexts;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class TypeOfCourseConverter
    {
        private readonly AppDBContext _dbContext;
        public TypeOfCourseConverter(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataResponseLoaiKhoaHoc EntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
        {
            return new DataResponseLoaiKhoaHoc
            {
                Id = loaiKhoaHoc.LoaiKhoaHocID,
                TenLoaiKhoaHoc = loaiKhoaHoc.TenLoai,
            };
        }
    }
}
