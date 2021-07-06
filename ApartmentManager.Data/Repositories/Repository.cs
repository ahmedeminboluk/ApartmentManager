using ApartmentManager.Core.Repositories;
using ApartmentManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApartmentManager.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApartmentManagerDbContext _context = null;
        private readonly DbSet<TEntity> _dbset = null;

        public Repository(ApartmentManagerDbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public async Task AddAllAsync(IEnumerable<TEntity> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            //_dbset.Update(entity);
            return entity;
        }
    }
}
