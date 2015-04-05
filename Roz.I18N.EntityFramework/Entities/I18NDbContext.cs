using System.Data.Entity;

namespace Roz.I18N.EntityFramework.Entities
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
