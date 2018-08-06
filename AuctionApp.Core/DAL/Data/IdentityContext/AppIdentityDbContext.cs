using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Core.DAL.Data.IdentityContext {
    public class AppIdentityDbContext : IdentityDbContext<AppUser> {
        public AppIdentityDbContext (DbContextOptions<AppIdentityDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<AppUser> (user => {
                user.Property (p => p.Name).HasMaxLength (30);
                user.Property (p => p.Surname).HasMaxLength (50);
                user.Property (p => p.Address).HasMaxLength (150);
                user.Property (p => p.Country).HasMaxLength (80);
                user.Property (p => p.PhotoSrc).IsRequired();
            });

            base.OnModelCreating (builder);
        }
    }
}