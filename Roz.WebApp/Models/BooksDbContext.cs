using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Roz.WebApp.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext()
            : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}