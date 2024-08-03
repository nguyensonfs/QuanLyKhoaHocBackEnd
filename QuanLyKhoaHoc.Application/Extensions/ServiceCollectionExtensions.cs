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
            services.AddScoped<TypeOfCourseConverter>();
            services.AddScoped<ITypeOfCourseService, TypeOfCourseService>();

            services.AddScoped<TypeOfArticleConverter>();
            services.AddScoped<ITypeOfArticleService, TypeOfArticleService>();

            services.AddScoped<RoleConverter>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<CourseConverter>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<TopicConverter>();
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
