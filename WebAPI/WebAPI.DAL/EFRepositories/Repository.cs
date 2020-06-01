using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DAL.Interfaces;

namespace WebAPI.DAL.EFRepositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private DbSet<TEntity> _entity;
        private DbContext _context;
        
        public Repository(DbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        
        public async Task<TEntity> GetAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var list = await _entity.ToListAsync();
            return list;
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entity.Where(predicate).ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
             _entity.Update(entity);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
        }
        // CRUD Create Read Update Delete
    }
}