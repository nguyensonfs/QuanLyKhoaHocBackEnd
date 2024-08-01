using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataArticles;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class ArticleConverter
    {
        public DataResponseArticle EntityToDTO(BaiViet bv)
        {
            return new DataResponseArticle
            {
                HinhAnh = bv.HinhAnh,
                BaiVietID = bv.BaiVietID,
                ChuDeID = bv.ChuDeID,
                NoiDung = bv.NoiDung,
                NoiDungNgan = bv.NoiDungNgan,
                TaiKhoanID = bv.TaiKhoanID,
                TenBaiViet = bv.TenBaiViet,
                TenTacGia = bv.TenTacGia,
                ThoiGianTao = bv.ThoiGianTao,
            };
        }
    }
}
