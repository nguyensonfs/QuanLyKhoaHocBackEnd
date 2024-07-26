using Microsoft.EntityFrameworkCore;
using QuanLyKhoaHoc.Domain.InterfaceRepositories;
using QuanLyKhoaHoc.Infrastructure.DataContexts;
using System.Linq.Expressions;

namespace QuanLyKhoaHoc.Infrastructure.ImplementRepositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected IDBContext _IDbContext = null;
        protected DbSet<TEntity> _dbset;
        protected DbContext _dbContext;

        protected DbSet<TEntity> DBSet
        {
            get
            {
                if (_dbset == null)
                {
                    _dbset = _dbContext.Set<TEntity>() as DbSet<TEntity>;
                }
                return _dbset;
            }
        }

        public BaseRepository(IDBContext dbContext)
        {
            _IDbContext = dbContext;
            _dbContext = (DbContext)dbContext;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = expression != null ? DBSet.Where(expression) : DBSet;
            return await query.CountAsync();
        }

        public async Task<int> CountAsync(string include, Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query;
            if (!string.IsNullOrEmpty(include))
            {
                query = BuildQueryable(new List<string> { include }, expression);
                return await query.CountAsync();
            }
            return await CountAsync(expression);
        }

        protected IQueryable<TEntity> BuildQueryable(List<string> includes, Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> query = DBSet.AsQueryable();
            if (expression != null)
            {
                query.Where(expression);
            }
            if (includes != null && includes.Count > 0)
            {
                foreach (string iclude in includes)
                {
                    query = query.Include(iclude.Trim());
                }
            }
            return query;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            DBSet.Add(entity);
            await _IDbContext.CommitChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities)
        {
            DBSet.AddRange(entities);
            await _IDbContext.CommitChangesAsync();
            return entities;
        }

        public async Task DeleteAsync(int id)
        {
            var dataEntity = await DBSet.FindAsync(id);
            if (dataEntity != null)
            {
                DBSet.Remove(dataEntity);
                await _IDbContext.CommitChangesAsync();
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> query = expression != null ? DBSet.Where(expression) : DBSet;
            var dataQuery = query;
            if (dataQuery != null)
            {
                DBSet.RemoveRange(dataQuery);
                await _IDbContext.CommitChangesAsync();
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = expression != null ? DBSet.Where(expression) : DBSet;
            return query;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DBSet.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await DBSet.FindAsync(Id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _IDbContext.CommitChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            await _IDbContext.CommitChangesAsync();
            return entities;
        }
    }
}
