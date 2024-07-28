using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;
using QuanLyKhoaHoc.Infrastructure.DataContexts;
using QuanLyKhoaHoc.Infrastructure.ImplementRepositories;

namespace QuanLyKhoaHoc.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDBContext, AppDBContext>();
            services.AddScoped<IBaseRepository<LoaiKhoaHoc>, BaseRepository<LoaiKhoaHoc>>();
        }
    }
}
