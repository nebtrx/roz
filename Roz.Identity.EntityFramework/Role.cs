﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Roz.Identity
{
    public class Role : IdentityRole<long, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
}