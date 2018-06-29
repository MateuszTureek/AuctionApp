using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Area("customer")]
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}