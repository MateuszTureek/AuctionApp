using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class AdminController : Controller
    {
        UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
    }
}