using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity
{
    public class RoleStore : RoleStore<Role, long, UserRole>
    {
        public RoleStore(DbContext context)
            : base(context)
        {
        }
    }
}