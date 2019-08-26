using CommonServiceLocator;
using StartUp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace StartUp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        protected DbTransaction DbTransaction;
        protected Dictionary<string, dynamic> Repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Repositories = new Dictionary<string, dynamic>();
        }

        public virtual IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<IGenericRepository<TEntity>>();
            }

            if (Repositories == null)
            {
                Repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;

            if (Repositories.ContainsKey(type))
            {
                return (IGenericRepository<TEntity>)Repositories[type];
            }

            var repositoryType = typeof(GenericRepository<>);

            Repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));

            return Repositories[type];
        }

        public virtual void SaveChange() => _context.SaveChanges();

        public virtual void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            DbTransaction = objectContext.Connection.BeginTransaction(isolationLevel);
        }
        public virtual bool Commit()
        {
            DbTransaction.Commit();
            return true;
        }

        public virtual void Rollback()
        {
            DbTransaction.Rollback();
        }

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
