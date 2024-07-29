using Microsoft.AspNetCore.Http;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.ChuDeRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataChuDe;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class ChuDeService : IChuDeService
    {
        private readonly IBaseRepository<ChuDe> _baseChuDeRepository;
        private readonly ChuDeConverter _chuDeConverter;
        private readonly IBaseRepository<LoaiBaiViet> _baseLoaiBaiVietRepository;

        public ChuDeService(IBaseRepository<ChuDe> baseChuDeRepository, ChuDeConverter chuDeConverter, IBaseRepository<LoaiBaiViet> baseLoaiBaiVietRepository)
        {
            _baseChuDeRepository = baseChuDeRepository;
            _chuDeConverter = chuDeConverter;
            _baseLoaiBaiVietRepository = baseLoaiBaiVietRepository;
        }

        public async Task<ResponseObject<DataResponseChuDe>> AddChuDe(Request_AddChuDe request)
        {
            try
            {
                var loaiBaiViet = await _baseLoaiBaiVietRepository.GetByIdAsync((int)request.LoaiBaiVietID);
                if (loaiBaiViet == null)
                {
                    return new ResponseObject<DataResponseChuDe>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy loại bài viết",
                        Data = null
                    };
                }

                var chuDe = new ChuDe
                {
                    TenChuDe = request.TenChuDe,
                    NoiDung = request.NoiDung,
                    LoaiBaiVietID = request.LoaiBaiVietID,
                };

                chuDe = await _baseChuDeRepository.CreateAsync(chuDe);

                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo chủ đề thành công",
                    Data = _chuDeConverter.EntityToDTO(chuDe)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseChuDe>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null
                };
            }
        }
    }
}
