using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity.EntityFramework
{
    public class UserStore : UserStore<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public UserStore(DbContext context)
            : base(context)
        {
        }
    }
}