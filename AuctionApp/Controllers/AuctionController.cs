using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class AuctionController : Controller
    {
        IAuctionService _service;

        public AuctionController(IAuctionService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LatestAuctions()
        {
            return PartialView("_LatestAuctionsPartial");
        }

        public IActionResult Item(int? id)
        {
            return View();
        }
    }
}