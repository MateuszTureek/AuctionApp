using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Core.DAL.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AuctionApp.Core.DAL.Data.IdentityContext
{
    public class IdentityInitializer
    {
        UserManager<AppUser> _userManager;
        AppIdentityDbContext _context;
        RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (_context.Users.Any())
            {
                return;
            }

            IdentityRole role1 = new IdentityRole(Role.customer);
            IdentityRole role2 = new IdentityRole(Role.admin);

            _roleManager.CreateAsync(role1).Wait();
            _roleManager.CreateAsync(role2).Wait();

            AppUser buyer = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Jan",
                Surname = "Kowalski",
                UserName = "buyer_1",
                Email = "buyer1@fake.com",
                PhoneNumber = "000 111 222",
                Address = "ul.Jana Pawła 23",
                Country = "Polska"
            };

            AppUser seller = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Paweł",
                Surname = "Nowak",
                UserName = "seller_1",
                Email = "seller1@fake.com",
                PhoneNumber = "222 444 000",
                Address = "ul.Łąkowa 9",
                Country = "Polska"
            };

            buyer.PasswordHash = _userManager.PasswordHasher.HashPassword(buyer, "12345");
            seller.PasswordHash = _userManager.PasswordHasher.HashPassword(seller, "12345");

            _userManager.CreateAsync(buyer).Wait();
            _userManager.CreateAsync(seller).Wait();

            _userManager.AddToRoleAsync(seller, role1.Name).Wait();
            _userManager.AddToRoleAsync(buyer, role1.Name).Wait();
        }
    }
}