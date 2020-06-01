using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.DAL.Interfaces
{
    // Обобщенное хранилище для всех классов CRUD операции 
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity,bool>> predicate);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}