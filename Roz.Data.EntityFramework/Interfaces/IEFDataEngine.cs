using System;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace Roz.Data.EntityFramework
{
    public interface IEFDataEngine : IDataEngine
    {
        Type GetEntityContextType(Type entityType);

        void RegisterInitializer<TDbContext>(IDatabaseInitializer<TDbContext> initializer)
            where TDbContext : DbContext;
    }
}