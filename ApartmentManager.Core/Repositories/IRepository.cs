using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddAllAsync(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAllPredicateAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
