using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roz.Data.EntityFramework.Utilities
{
    public static class Extensions
    {
        public static IQueryable<T> Query<T>(this DbSet<T> dbSet) where T : class
        {
            return dbSet.AsQueryable();
        }
    }
}
