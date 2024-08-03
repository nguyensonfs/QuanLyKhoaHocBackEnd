
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTypeOfArticle;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Infrastructure.DataContexts;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class TypeOfArticleConverter
    {
        public DataResponseTypeOfArticle EntityToDTO(LoaiBaiViet loaiBaiViet)
        {
            return new DataResponseTypeOfArticle
            {
                Id = loaiBaiViet.LoaiBaiVietID,
                TenLoaiBaiViet = loaiBaiViet.TenLoai,
            };
        }
    }
}
