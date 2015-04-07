using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity.EntityFramework
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class IdentityDbContext : IdentityDbContext<User, Role, long, UserLogin, UserRole, UserClaim> 
    {
        public IdentityDbContext()
            : base("DefaultConnection")
        {
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}