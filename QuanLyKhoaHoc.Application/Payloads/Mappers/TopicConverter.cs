using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataChuDe;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class TopicConverter
    {
        public DataResponseChuDe EntityToDTO(ChuDe chuDe)
        {
            return new DataResponseChuDe
            {
                ChuDeID = chuDe.ChuDeID,
                TenChuDe = chuDe.TenChuDe,
                NoiDung = chuDe.NoiDung,
                LoaiBaiVietID = chuDe.LoaiBaiVietID,
            };
        }
    }
}
