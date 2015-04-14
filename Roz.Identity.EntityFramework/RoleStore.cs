using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity.EntityFramework
{
    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(DbContext context)
            : base(context)
        {
        }
    }
}