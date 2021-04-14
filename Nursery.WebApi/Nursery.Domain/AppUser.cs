using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nursery.Domain
{
    public class AppUser : IdentityUser<long>
    {
        public string DisplayName { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
