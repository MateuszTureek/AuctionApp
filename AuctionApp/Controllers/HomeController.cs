using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            return View ();
        }

        public IActionResult HowToOffer () {
            return View ();
        }

        public IActionResult About () {
            return View ();
        }

        public IActionResult Contact () {
            return View ();
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}