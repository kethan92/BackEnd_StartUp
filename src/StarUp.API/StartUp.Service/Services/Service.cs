using StartUp.Data.Exceptions;
using StartUp.Data.Repositories;
using StartUp.Data.UnitOfWork;
using StartUp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Service.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;

        protected Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<TEntity>();
        }

        /// <summary>
        /// Queryable
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Queryable() => _repository.Queryable();

        /// <summary>
        /// Generic get for entity
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

        /// <summary>
        /// Insert a new TEntity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {

            _repository.Insert(entity);
            _unitOfWork.SaveChange();
        }

        /// <summary>
        /// Delete TEntity by primary key
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _repository.GetById(id);
            if (entityToDelete == null)
                throw new DataNotFoundException($"Could not find {typeof(TEntity).Name} with id {id}");
            _repository.Delete(entityToDelete);
            _unitOfWork.SaveChange();
        }

        /// <summary>
        /// Update enitty
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public virtual void Update(int id, TEntity entity)
        {
            try
            {
                _repository.Update(entity);
                _unitOfWork.SaveChange();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(id))
                {
                    throw new DataNotFoundException($"Could not find {typeof(TEntity).Name} with id {id}");
                }
                throw;
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            try
            {
                _repository.Update(entity);
                _unitOfWork.SaveChange();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        /// <summary>
        /// Apply change to context
        /// </summary>
        public void ApplyChange()
        {
            _unitOfWork.SaveChange();
        }

        /// <summary>
        /// Get many TEntity base on condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return _repository.GetMany(where);
        }

        /// <summary>
        /// Get many TEntity as Queryable
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return _repository.GetManyQueryable(where);
        }

        /// <summary>
        /// Get single TEntity base on conditions
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public TEntity Get(Func<TEntity, bool> where)
        {
            return _repository.Get(where);
        }

        /// <summary>
        /// Delete many TEntity baes on conditions
        /// </summary>
        /// <param name="where"></param>
        public void Delete(Func<TEntity, bool> where)
        {
            _repository.Delete(where);
            _unitOfWork.SaveChange();
        }

        /// <summary>
        /// Query TEntity with include
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            return _repository.GetWithInclude(predicate, include);
        }

        /// <summary>
        /// Check if a TEntity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            return _repository.Exists(primaryKey);
        }

        /// <summary>
        /// Get signle TEntity
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return _repository.GetSingle(predicate);
        }

        /// <summary>
        /// Get first TEntity
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return _repository.GetFirst(predicate);
        }
    }
}
