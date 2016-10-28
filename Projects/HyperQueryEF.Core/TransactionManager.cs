using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace HyperQueryEF.Core
{
    public class TransactionManager<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly List<KeyValuePair<int, object>> _contextObjects;

        public TransactionManager(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _contextObjects = new List<KeyValuePair<int, object>>();
        }

        private static int ThreadId { get { return Thread.CurrentThread.ManagedThreadId; } }
        
        private IEnumerable<object> ObjectsAttachedToCurrentContext
        {
            get
            {
                lock (_contextObjects)
                {
                    if (!_contextObjects.Any())
                        return new List<object>();

                    var contextObjectsPerThread = _contextObjects.ToLookup(kvp => kvp.Key, kvp => kvp.Value);
                    return contextObjectsPerThread[ThreadId];
                }
            }
        }

        public void Attach<T>(T entity) where T : class
        {
            lock (_contextObjects)
            {
                _contextObjects.Add(new KeyValuePair<int, object>(ThreadId, entity));
            }
        }

        public T Get<T>(params object[] ids) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.Get<T>(ids);
            }
        }

        public T Get<T>(Func<T, bool> expression) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.Get(expression);
            }
        }

        public int GetCount<T>() where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.GetCount<T>();
            }
        }

        public T GetRandom<T>() where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.GetRandom<T>();
            }
        }

        public T GetRandom<T>(Func<T, bool> expression) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.GetRandom(expression);
            }
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.GetAll<T>();
            }
        }

        public IQueryable<T> GetAll<T>(Func<T, bool> expression) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                return unitOfWork.GetAll(expression);
            }
        }

        public void Save<T>(T entity) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                foreach (var obj in ObjectsAttachedToCurrentContext)
                {
                    AttachBoxedObjectToUnitOfWork(obj, unitOfWork);
                }
                unitOfWork.Save(entity);
                unitOfWork.SaveChanges();
            }

            //TODO:  Ensure that thread objects from the _contextObjects field truly are removed
            lock (_contextObjects)
            {
                _contextObjects.RemoveAll(kvp => kvp.Key == ThreadId);
            }
        }

        public void Save<T>(IEnumerable<T> entities) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                foreach (var obj in ObjectsAttachedToCurrentContext)
                {
                    AttachBoxedObjectToUnitOfWork(obj, unitOfWork);
                }
                unitOfWork.Save(entities);
                unitOfWork.SaveChanges();
            }

            lock (_contextObjects)
            {
                _contextObjects.RemoveAll(kvp => kvp.Key == ThreadId);
            }
        }

        public void Update<T>(T entity) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                unitOfWork.Update(entity);
                unitOfWork.SaveChanges();
            }
        }

        public void Update<T>(IEnumerable<T> entities) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                unitOfWork.Update(entities);
                unitOfWork.SaveChanges();
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            using (var unitOfWork = _unitOfWorkFactory.CreatePersistenceManager<TContext>(LifestyleType.Transient))
            {
                unitOfWork.Delete(entity);
                unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Use reflection to force Attach() method to be generic to whatever type of object passed into it.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="unitOfWork"></param>
        private static void AttachBoxedObjectToUnitOfWork(object obj, IUnitOfWork unitOfWork)
        {
            var method = unitOfWork.GetType().GetMethod("Attach");
            var genericMethod = method.MakeGenericMethod(obj.GetType());
            genericMethod.Invoke(unitOfWork, new[] { obj });
        }
    }
}
