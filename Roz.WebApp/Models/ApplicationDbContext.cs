using Microsoft.AspNet.Identity.EntityFramework;
using Roz.Identity;

namespace Roz.WebApp.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<User, Role, long, UserLogin, UserRole, UserClaim> 
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}