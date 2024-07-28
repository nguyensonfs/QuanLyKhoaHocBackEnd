
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiBaiViet;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Infrastructure.DataContexts;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class LoaiBaiVietConverter
    {
        private readonly AppDBContext _dbContext;
        public LoaiBaiVietConverter(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataResponseLoaiBaiViet EntityToDTO(LoaiBaiViet loaiBaiViet)
        {
            return new DataResponseLoaiBaiViet
            {
                Id = loaiBaiViet.LoaiBaiVietID,
                TenLoaiBaiViet = loaiBaiViet.TenLoai,
            };
        }
    }
}
