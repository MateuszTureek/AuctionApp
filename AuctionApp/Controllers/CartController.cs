using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class CartController : Controller
    {
        readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}