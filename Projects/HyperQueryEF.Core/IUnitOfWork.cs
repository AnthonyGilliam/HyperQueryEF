using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HyperQueryEF.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Attach<T>(T entity) where T : class;
        T Get<T>(params object[] ids) where T : class;
        T Get<T>(Func<T, bool> expression) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> GetAll<T>(Expression<Func<T, bool>> expression) where T : class;
        int GetCount<T>() where T : class;
        T GetRandom<T, O>(Func<T, O> orderByExpression) where T : class;
        T GetRandom<T, O>(Func<T, bool> expression, Func<T, O> orderByExpression) where T : class;
        void Save<T>(T entity) where T : class;
        void Save<T>(IEnumerable<T> entities) where T : class;
        void Update<T>(T entity) where T : class;
        void Update<T>(IEnumerable<T> entities) where T : class;
        void Delete<T>(T entity) where T : class;
        bool HasChanges();
        void SaveChanges();
    }
}