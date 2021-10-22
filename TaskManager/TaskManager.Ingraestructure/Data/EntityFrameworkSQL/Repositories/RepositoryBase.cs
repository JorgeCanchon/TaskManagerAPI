using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces.Repositories;

namespace TaskManager.Infraestructure.Data.EntityFrameworkSQL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext Context { get; set; }
        private bool _disposed;

        protected RepositoryBase(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Create(T entity)
        {
            var person = Context.Set<T>().Add(entity);
            Context.SaveChanges();
            person.State = EntityState.Detached;
            return person.Entity;
        }

        public EntityState Delete(T entity)
        {
            EntityState entityState = Context.Set<T>().Remove(entity).State;
            Context.SaveChanges();
            return entityState;
        }

        public IQueryable<T> ExecuteQuery(string sql) =>
            Context.Set<T>().FromSqlRaw<T>(sql).AsNoTracking();

        public IQueryable<T> FindAll() =>
            Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public EntityState Update(T entity, string propertyName)
        {
            Context.Entry<T>(entity).Property(propertyName).IsModified = false;
            EntityState entityState = Context.Set<T>().Update(entity).State;
            Context.SaveChanges();
            Context.Set<T>().Update(entity).State = EntityState.Detached;
            return entityState;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
            _disposed = true;
        }
    }
}
