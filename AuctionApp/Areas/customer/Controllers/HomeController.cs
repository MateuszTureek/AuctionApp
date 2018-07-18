using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.DAL.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Authorize(Roles = Role.customer)]
    [Area("customer")]
    public class HomeController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}