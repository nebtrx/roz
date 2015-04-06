using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.WebApp.Models
{
    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}