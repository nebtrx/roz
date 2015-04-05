using System.Data.Entity;

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
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}