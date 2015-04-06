using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.WebApp.Models
{
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}