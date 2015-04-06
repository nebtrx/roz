using System.Data.Entity.Migrations;

namespace Roz.WebApp.Migrations.Books
{
    internal sealed class ConfigurationBooks : DbMigrationsConfiguration<Roz.WebApp.Models.BooksDbContext>
    {
        public ConfigurationBooks()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Roz.WebApp.Models.BooksDbContext";
        }

        protected override void Seed(Roz.WebApp.Models.BooksDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
