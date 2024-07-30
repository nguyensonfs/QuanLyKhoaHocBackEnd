using Microsoft.AspNetCore.Http;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentStatusRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataStudentStatus;
using QuanLyKhoaHoc.Application.Payloads.Responses;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;
using System;

namespace QuanLyKhoaHoc.Application.ImplementServices
{
    public class StudentStatusService : IStudentStatusService
    {
        private readonly IBaseRepository<TinhTrangHoc> _baseTinhTrangHocRepository;
        private readonly StudentStatusConverter _studentStatusConverter;

        public StudentStatusService(IBaseRepository<TinhTrangHoc> baseTinhTrangHocRepository,
                                    StudentStatusConverter studentStatusConverter)
        {
            _baseTinhTrangHocRepository = baseTinhTrangHocRepository;
            _studentStatusConverter = studentStatusConverter;
        }

        public async Task<ResponseObject<DataResponseStudentStatus>> CreateStudentStatus(Request_CreateStudentStatus request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.StudentStatusName))
                {
                    return new ResponseObject<DataResponseStudentStatus>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }

                var studentStatus = new TinhTrangHoc
                {
                    TenTinhTrang = request.StudentStatusName
                };

                studentStatus = await _baseTinhTrangHocRepository.CreateAsync(studentStatus);

                return new ResponseObject<DataResponseStudentStatus>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Create Success !!!",
                    Data = _studentStatusConverter.EntityToDTO(studentStatus)
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<DataResponseStudentStatus>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + e.Message,
                    Data = null,
                };
            }
        }
    }
}
