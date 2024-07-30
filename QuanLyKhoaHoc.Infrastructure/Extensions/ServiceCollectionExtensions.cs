using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoaHoc.Domain.Entities;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;
using QuanLyKhoaHoc.Infrastructure.DataContexts;
using QuanLyKhoaHoc.Infrastructure.ImplementRepositories;
using System.Net;

namespace QuanLyKhoaHoc.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var hostName = Dns.GetHostName();

            var connections = configuration.GetSection("ConnectionStrings").GetChildren().ToDictionary(x => x.Key, x => x.Value);

            if (!connections.TryGetValue(hostName, out var connectionString))
            {
                throw new InvalidOperationException($"No connection string configured for host {hostName}");
            }


            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDBContext, AppDBContext>();
            services.AddScoped<IBaseRepository<LoaiKhoaHoc>, BaseRepository<LoaiKhoaHoc>>();
            services.AddScoped<IBaseRepository<LoaiBaiViet>, BaseRepository<LoaiBaiViet>>();
            services.AddScoped<IBaseRepository<QuyenHan>, BaseRepository<QuyenHan>>();
            services.AddScoped<IBaseRepository<KhoaHoc>, BaseRepository<KhoaHoc>>();
            services.AddScoped<IBaseRepository<ChuDe>, BaseRepository<ChuDe>>();
            services.AddScoped<IBaseRepository<HocVien>, BaseRepository<HocVien>>();
            services.AddScoped<IBaseRepository<TinhTrangHoc>, BaseRepository<TinhTrangHoc>>();
        }
    }
}
