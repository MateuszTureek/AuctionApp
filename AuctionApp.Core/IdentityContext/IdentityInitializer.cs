using AuctionApp.Core.IdentityContext.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.IdentityContext
{
    public class IdentityInitializer
    {
        UserManager<AppUser> _userManager;
        AppIdentityDbContext _context;

        public IdentityInitializer(UserManager<AppUser> userManager, AppIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (_context.Users.Any())
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

            _userManager.PasswordHasher.HashPassword(buyer, "12345");
            _userManager.PasswordHasher.HashPassword(seller, "12345");

            var r1 = _userManager.CreateAsync(buyer).Result;
            var r2 = _userManager.CreateAsync(seller).Result;
        }
    }
}
