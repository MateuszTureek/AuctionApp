using AuctionApp.Domain.Identity;
using AuctionApp.Web.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.DatabaseInitial
{
    public class IdentityInitializer
    {
        UserManager<AppUser> userManager;

        public IdentityInitializer(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public void Initialize(AppIdentityDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            AppUser buyer = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "buyer_1",
                Email = "buyer1@fake.com"
            };

            AppUser seller = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "seller_1",
                Email = "seller1@fake.com"
            };

            userManager.PasswordHasher.HashPassword(buyer, "12345");
            userManager.PasswordHasher.HashPassword(seller, "12345");

            var r1 = userManager.CreateAsync(buyer).Result;
            var r2 = userManager.CreateAsync(seller).Result;
        }
    }
}
