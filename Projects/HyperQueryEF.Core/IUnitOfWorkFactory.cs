using System;
using System.Data.Entity;

namespace HyperQueryEF.Core
{
    /// <summary>
    /// Uses Castle Windsor's Typed Factory Facility and Typed Factory Component Selector features to select the registered IPersistenceManager service installed using Windsor. 
    /// </summary>
    public interface IUnitOfWorkFactory : IDisposable
    {
        /// <summary>
        /// Returns a PersistenceManager from the services registered in the WindsorInstaller class having the given context and dependency injection lifestyle.
        /// </summary>
        /// <typeparam name="TContext">Entity Framework database context to make persistenceManager generic to.</typeparam>
        /// <param name="lifestyle">Shelf-life of dependency injected object</param>
        /// <returns></returns>
        IPersistenceManager CreatePersistenceManager<TContext>(LifestyleType lifestyle) where TContext : DbContext;

        /// <summary>
        /// Mark the given UnitOfWork for garbage collection.
        /// </summary>
        /// <param name="unitOfWork"></param>
        void Release(IUnitOfWork unitOfWork);
    }
}