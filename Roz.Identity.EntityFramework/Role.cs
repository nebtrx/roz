using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity.EntityFramework
{
    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
}