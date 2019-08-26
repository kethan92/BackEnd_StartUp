using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartUp.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Queryable();
        void Delete(Func<TEntity, bool> where);
        void Delete(object id);
        void Delete(TEntity entity);
        bool Exists(object primaryKey);
        IEnumerable<TEntity> Get();
        TEntity Get(Func<TEntity, bool> where);
        TEntity GetById(object id);
        TEntity GetFirst(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);
        TEntity GetSingle(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
