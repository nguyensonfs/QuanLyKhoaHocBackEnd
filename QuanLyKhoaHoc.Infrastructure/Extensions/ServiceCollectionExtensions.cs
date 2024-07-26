using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoaHoc.Infrastructure.DataContexts;

namespace QuanLyKhoaHoc.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services) {
            services.AddDbContext<AppDBContext>();
        }
    }
}
