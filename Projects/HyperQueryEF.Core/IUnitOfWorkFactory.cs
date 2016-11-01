using System;
using System.Data.Entity;

namespace HyperQueryEF.Core
{
    /// <summary>
    /// Factory to produce a unit of work as either a PersistenceManager or Transaction manager based on constructor parameter
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Returns a unit of work of constructor defined type
        /// </summary>
        /// <typeparam name="TContext">Database context to make unit of work generic to.</typeparam>
        /// <param name="unitOfWorkType">Transient or persistent unit of work</param>
        /// <returns></returns>
        IUnitOfWork Create<TContext>(UnitOfWorkType unitOfWorkType) where TContext : DbContext;
    }
}