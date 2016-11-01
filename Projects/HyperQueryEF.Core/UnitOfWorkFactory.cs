using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperQueryEF.Core
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create<TContext>(UnitOfWorkType unitOfWorkType) where TContext : DbContext
        {
            var constructorInfo = typeof(TContext).GetConstructor(new Type[] {});
            if (constructorInfo == null)
                throw new TargetParameterCountException("Cannot generically create a DbContext with constructor parameters");

            var dbContext = constructorInfo.Invoke(new object[] {}) as TContext;


            return unitOfWorkType == UnitOfWorkType.Persistent
                ? new PersistenceManager<TContext>(dbContext)
                : new TransactionManager<TContext>() as IUnitOfWork;
        }
    }
}
