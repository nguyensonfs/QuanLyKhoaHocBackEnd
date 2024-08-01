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

            services.AddScoped<LoaiBaiVietConverter>();
            services.AddScoped<ILoaiBaiVietService, LoaiBaiVietService>();

            services.AddScoped<QuyenHanConverter>();
            services.AddScoped<IQuyenHanService, QuyenHanService>();

            services.AddScoped<KhoaHocConverter>();
            services.AddScoped<IKhoaHocService, KhoaHocService>();

            services.AddScoped<ChuDeConverter>();
            services.AddScoped<IChuDeService, ChuDeService>();

            services.AddScoped<StudentConverter>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<StudentStatusConverter>();
            services.AddScoped<IStudentStatusService, StudentStatusService>();

            services.AddScoped<AccountConverter>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ArticleConverter>();
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}
