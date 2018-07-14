using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
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