using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nursery.Domain;
using System;

namespace Nursery.EFData
{
    public class EFDataContext : IdentityDbContext<AppUser, AppRole, long, IdentityUserClaim<long>,
                    AppUserRole, IdentityUserLogin<long>,
                    IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public EFDataContext(DbContextOptions<EFDataContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
