using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity.EntityFramework
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class IdentityDbContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim> 
    {
        public IdentityDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<UserLogin>().HasKey<int>(l => l.UserId).ToTable("UserLogin");
            modelBuilder.Entity<UserRole>().HasKey(r => new { r.RoleId, r.UserId }).ToTable("UserRole");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserClaim>().HasKey(c => c.Id).ToTable("UserClaim");
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}