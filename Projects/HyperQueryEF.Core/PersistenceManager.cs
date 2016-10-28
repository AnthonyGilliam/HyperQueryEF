using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().AsQueryable<T>();
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return GetAll<T>().Where(expression);
        }

        public int GetCount<T>() where T : class
        {
            return _dbContext.Set<T>().Count();
        }

        public T GetRandom<T>() where T : class
        {
            var rowcount = GetCount<T>();

            if (rowcount <= 0)
                return null;

            var randomIndex = new Random().Next(rowcount);

            return _dbContext.Set<T>()
                .Skip(randomIndex)
                .FirstOrDefault();
        }

        public T GetRandom<T>(Func<T, bool> expression) where T : class
        {
            var rowcount = _dbContext.Set<T>().Count(expression);

            if (rowcount <= 0)
                return null;

            var randomIndex = new Random().Next(rowcount);

            return _dbContext.Set<T>()
                .Skip(randomIndex)
                .FirstOrDefault();
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

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
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
