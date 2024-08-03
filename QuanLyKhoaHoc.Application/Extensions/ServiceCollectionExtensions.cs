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
            services.AddScoped<ITypeOfCourseService, LoaiKhoaHocService>();

            services.AddScoped<LoaiBaiVietConverter>();
            services.AddScoped<ITypeOfArticleService, TypeOfArticleService>();

            services.AddScoped<QuyenHanConverter>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<KhoaHocConverter>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<ChuDeConverter>();
            services.AddScoped<ITopicService, TopicService>();

            services.AddScoped<StudentConverter>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<LearningStatusConverter>();
            services.AddScoped<ILearningStatusService, LearningStatusService>();

            services.AddScoped<AccountConverter>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ArticleConverter>();
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}
