using ApartmentManager.Core;
using ApartmentManager.Core.Repositories;
using ApartmentManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitofWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public Service(IUnitofWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> AddAllAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddAllAsync(entities);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            return await _unitOfWork.CommitAsync();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ICollection<TEntity>> GetAllPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAllPredicateAsync(predicate);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }
    }
}
