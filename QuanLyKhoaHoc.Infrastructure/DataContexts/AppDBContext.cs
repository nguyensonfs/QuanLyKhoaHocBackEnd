using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Domain.Entities;

namespace QuanLyKhoaHoc.Infrastructure.DataContexts
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public AppDBContext() { }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DangKyHoc> DangKyHocs { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
        public virtual DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }
        public virtual DbSet<QuyenHan> QuyenHans { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinhTrangHoc> TinhTrangHocs { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
