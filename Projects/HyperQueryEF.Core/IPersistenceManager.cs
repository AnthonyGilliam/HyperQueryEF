using System;

namespace HyperQueryEF.Core
{
    public interface IPersistenceManager : IUnitOfWork, IDisposable
    {
        bool HasChanges();
        void SaveChanges();
    }
}
