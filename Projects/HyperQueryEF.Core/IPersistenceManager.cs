using System;

namespace HyperQueryEF.Core
{
    /// <summary>
    /// Unit of work used to administrate the caching and committing of persistent objects to a configured data source.
    /// </summary>
    public interface IPersistenceManager : IUnitOfWork, IDisposable
    {
        bool HasChanges();
        void SaveChanges();
    }
}
