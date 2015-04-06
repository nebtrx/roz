using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.WebApp.Models
{
    public class CustomRole : IdentityRole<long, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}