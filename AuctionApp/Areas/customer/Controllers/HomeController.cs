using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Authorize(Roles = Role.customer)]
    [Area("customer")]
    public class HomeController : Controller
    {
        readonly IItemService _itemService;
        readonly IOrderService _orderService;

        public HomeController(IItemService itemService, IOrderService orderService)
        {
            _itemService = itemService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier);

            ViewBag.WaitingItemsCount = _itemService.AmountOfWaitingItems(claimUserId.Value);
            ViewBag.InAuctionItemsCount = _itemService.AmountOfAuctions(claimUserId.Value);
            ViewBag.FinancialLiabilities = _orderService.GetTotalLiabilities(claimUserId.Value);
            ViewBag.MyLeadBidsAmount = _itemService.GetLeadBidOfItem(claimUserId.Value);

            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}