using System.Data.Entity;
using Roz.I18N.EntityFramework.Entities;

namespace Roz.I18N.EntityFramework
{
    public class I18NDbContext : DbContext
    {
        public I18NDbContext()
            :base("DefaultConnection")
        {
            
        }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ResourceValue> ResourceValues { get; set; }

    }
}
