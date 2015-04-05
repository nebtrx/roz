using System.Data.Entity.Migrations;

namespace Roz.WebApp.Migrations.Application
{
    internal sealed class ConfigurationApplication : DbMigrationsConfiguration<Roz.WebApp.Models.ApplicationDbContext>
    {
        public ConfigurationApplication()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Roz.WebApp.Models.ApplicationDbContext";
        }

        protected override void Seed(Roz.WebApp.Models.ApplicationDbContext context)
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
