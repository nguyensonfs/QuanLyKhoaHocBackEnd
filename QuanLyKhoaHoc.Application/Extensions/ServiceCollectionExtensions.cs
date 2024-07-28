using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoaHoc.Application.ImplementServices;
using QuanLyKhoaHoc.Application.InterfaceServices;
using QuanLyKhoaHoc.Application.Payloads.Mappers;

namespace QuanLyKhoaHoc.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<LoaiKhoaHocConverter>();
            services.AddScoped<ILoaiKhoaHocService, LoaiKhoaHocService>();
        }
    }
}
