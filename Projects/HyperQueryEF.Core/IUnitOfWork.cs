using System;
using System.Collections.Generic;

namespace HyperQueryEF.Core
{
    public interface IUnitOfWork
    {
        void Attach<T>(T entity) where T : class;
        T Get<T>(params object[] ids) where T : class;
        T Get<T>(Func<T, bool> expression) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> GetAll<T>(Func<T, bool> expression) where T : class;
        void Save<T>(T entity) where T : class;
        void Save<T>(IEnumerable<T> entities) where T : class;
        void Update<T>(T entity) where T : class;
        void Update<T>(IEnumerable<T> entities) where T : class;
    }
}