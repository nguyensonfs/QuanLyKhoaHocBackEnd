
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiBaiViet;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Infrastructure.DataContexts;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class TypeOfArticleConverter
    {
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
