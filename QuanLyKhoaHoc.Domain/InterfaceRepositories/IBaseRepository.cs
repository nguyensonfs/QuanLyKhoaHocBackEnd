﻿using System.Linq.Expressions;

namespace QuanLyKhoaHoc.Domain.InterfaceRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(int Id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(int id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<int> CountAsync(string include, Expression<Func<TEntity, bool>> expression = null);
    }
}
