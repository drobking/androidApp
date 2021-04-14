using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursery.Domain
{
    public class AppUserRole : IdentityUserRole<long>
    {
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
