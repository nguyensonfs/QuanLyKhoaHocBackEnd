using Microsoft.EntityFrameworkCore;
namespace QuanLyKhoaHoc.Infrastructure.DataContexts
{
    public interface IDBContext : IDisposable
    {
        DbSet<TEntity> SetEntity <TEntity>() where TEntity : class;
        Task<int> CommitChangesAsync();
    }
}
