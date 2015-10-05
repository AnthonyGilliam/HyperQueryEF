using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HyperQueryEF.Core
{
    public class PersistenceManager<TContext> : IPersistenceManager where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public PersistenceManager(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Attach<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Attach(entity);
        }

        public T Get<T>(params object[] ids) where T : class
        {
            return _dbContext.Set<T>().Find(ids);
        }

        public T Get<T>(Func<T, bool> expression) where T : class
        {
            return _dbContext.Set<T>().SingleOrDefault(expression);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().AsQueryable<T>();
        }

        public IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class
        {
            return GetAll<T>().Where(expression);
        }

        public void Save<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Save<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update<T>(IEnumerable<T> entities) where T : class
        {
            entities.ToList().ForEach(Update);
        }

        public bool HasChanges()
        {
            return _dbContext.ChangeTracker.HasChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
