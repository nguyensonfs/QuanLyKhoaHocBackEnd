using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataTopic;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Application.Payloads.Mappers
{
    public class TopicConverter
    {
        public DataResponseTopic EntityToDTO(ChuDe chuDe)
        {
            return new DataResponseTopic
            {
                ChuDeID = chuDe.ChuDeID,
                TenChuDe = chuDe.TenChuDe,
                NoiDung = chuDe.NoiDung,
                LoaiBaiVietID = chuDe.LoaiBaiVietID,
            };
        }
    }
}
