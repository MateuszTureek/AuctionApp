using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Auction;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Area("customer")]
    public class ItemController : Controller
    {
        readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CancelAuctionOfItem(int? id)
        {
            if (id == null) return BadRequest();
            _itemService.ChangeStatus((int)id, Core.DAL.Data.AuctionContext.Domain.Status.Waiting);
            return Ok("");
        }

        public IActionResult GetItemBids(int? id)
        {
            if (id == null) return BadRequest();
            var dto = _itemService.GetAuctionByItem((int)id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult ItemToAuction(CreateAuctionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is not valid.");
                return Json(ModelState);
            }

            _itemService.SetAuction(dto);
            return RedirectToAction("Index", "Item", new { area = "customer" });
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            _itemService.Remove((int)id);
            return RedirectToAction("Index", "Item", new { area = "customer" });
        }

        [HttpGet]
        public IActionResult GetWaitingItems(
            int amountOfPages,
            string phrase = "",
            bool desc = false,
            WaitingItemsOrderBy orderBy = WaitingItemsOrderBy.Name)
        {
            var result = _itemService.GetWaitingItems(orderBy, desc, phrase, amountOfPages);
            return Json(result);
        }
        
        [HttpGet]
        public IActionResult GetInAuctionItems(
            int amountOfPages,
            string phrase = "",
            bool desc = false,
            InAuctionItemsOrderBy orderBy = InAuctionItemsOrderBy.Name)
      {
            var result = _itemService.GetInAuctionItems(orderBy, desc, phrase, amountOfPages);
            return Json(result);
        }
        
        [HttpGet]
        public IActionResult GetBoughtItems(
            int amountOfPages,
            string phrase = "",
            bool desc = false,
            BoughtItemsOrderBy orderBy = BoughtItemsOrderBy.Name)
        {
            var result = _itemService.GetBoughtItems(orderBy, desc, phrase, amountOfPages);
            return Json(result);
        }
    }
}