using Microsoft.AspNetCore.Http;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;
using QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentStatusRequests;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc;
using QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataQuyenHan;
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

        public async Task<string> Delete(int statusId)
        {
            var studentStatus = await _baseTinhTrangHocRepository.GetByIdAsync(statusId);
            if (studentStatus == null)
            {
                return "Trạng thái không tồn tại";
            }
            await _baseTinhTrangHocRepository.DeleteAsync(statusId);
            return "Xoá thành công";
        }

        public Task<IQueryable<DataResponseStudentStatus>> GetAlls()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseObject<DataResponseStudentStatus>> UpdateStudentStatus(Request_UpdateStudentStatus request)
        {
            try
            {
                var studentStatus = await _baseTinhTrangHocRepository.GetByIdAsync(request.Id);
                if (studentStatus == null)
                {
                    return new ResponseObject<DataResponseStudentStatus>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Trạng thái không tồn tại",
                        Data = null,
                    };
                }
                if (string.IsNullOrEmpty(request.StudentStatusName))
                {
                    return new ResponseObject<DataResponseStudentStatus>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Vui lòng điền đầy đủ thông tin",
                        Data = null,
                    };
                }
                studentStatus.TenTinhTrang = request.StudentStatusName;
                studentStatus = await _baseTinhTrangHocRepository.UpdateAsync(studentStatus);

                return new ResponseObject<DataResponseStudentStatus>
                {
                    Status = StatusCodes.Status201Created,
                    Message = "Cập nhật loại khoá học thành công",
                    Data = _studentStatusConverter.EntityToDTO(studentStatus)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseStudentStatus>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Có lỗi: " + ex.Message,
                    Data = null,
                };
            }
        }
    }
}
