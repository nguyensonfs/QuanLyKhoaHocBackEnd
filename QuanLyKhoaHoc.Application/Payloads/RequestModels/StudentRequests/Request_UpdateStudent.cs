using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoaHoc.Application.Payloads.RequestModels.StudentRequests
{
    public class Request_UpdateStudent
    {

        public IFormFile? HinhAnh { get; set; }

        [Required]
        public string HoTen { get; set; } = string.Empty;

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        public string SoDienThoai { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? TinhThanh { get; set; }

        public string? QuanHuyen { get; set; }

        public string? PhuongXa { get; set; }

        public string? SoNha { get; set; }
    }
}
