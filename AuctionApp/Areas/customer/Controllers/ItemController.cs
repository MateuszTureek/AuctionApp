using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using AuctionApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuctionApp.Areas.customer.Controllers
{
    [Area("customer")]
    [Authorize(Roles = Role.customer)]
    public class ItemController : Controller
    {
        readonly IMapper _mappper;
        readonly IItemService _itemService;

        public ItemController(IItemService itemService, IMapper mapper, IPhotoService photoService)
        {
            _itemService = itemService;
            _mappper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string username = User.FindFirst(ClaimTypes.Name).Value;
                NewItemDTO dto = _mappper.Map<NewItemViewModel, NewItemDTO>(model);
                dto.UserId = userId;
                dto.Username = username;

                await _itemService.CreateAsync(dto);

                return RedirectToAction("Index", "Home", new { area = "customer" });
            }
            ModelState.AddModelError(string.Empty, "Niepoprawne dane produktu.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuctionOfItem(CreateAuctionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Niepoprawne dane.");
                return BadRequest();
            }

            var dto = _mappper.Map<CreateAuctionViewModel, CreateAuctionDTO>(model);
            await _itemService.CreateItemAuctionAsync(dto);

            return RedirectToAction("Index", "Item", new { area = "customer" });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuctionBid(NewBidViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Niepoprawne dane.");
                return RedirectToAction("Item", "Item", new { id = model.ItemId, area = "" });
            }
            NewBidDTO dto = _mappper.Map<NewBidViewModel, NewBidDTO>(model);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string username = User.FindFirst(ClaimTypes.Name).Value;
            dto.Username = username;
            await _itemService.AddBidToItemAsync(dto, userId);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            await _itemService.RemoveAsync((int)id);
            return RedirectToAction("Index", "Item", new { area = "customer" });
        }

        [HttpGet]
        public async Task<IActionResult> GetItemBids(int? id)
        {
            if (id == null) return BadRequest();
            var dto = await _itemService.GetAuctionDetailsAsync((int)id);
            var result = _mappper.Map<ItemAuctionDTO, ItemAuctionViewModel>(dto);
            return View(result);
        }

        [HttpGet]
        public IActionResult GetWaitingItems(SearchCriteriaDTO searchDTO, WaitingItemsOrderBy orderBy = WaitingItemsOrderBy.Name)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            searchDTO.UserId = userId;
            var result = _itemService.GetWaitingItems(orderBy, searchDTO);
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetInAuctionItems(SearchCriteriaDTO searchDTO, InAuctionItemsOrderBy orderBy = InAuctionItemsOrderBy.Name)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            searchDTO.UserId = userId;
            var result = _itemService.GetInAuctionItems(orderBy, searchDTO);
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetBoughtItems(SearchCriteriaDTO searchDTO, BoughtItemsOrderBy orderBy = BoughtItemsOrderBy.Name)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            searchDTO.UserId = userId;
            var result = _itemService.GetBoughtItems(orderBy, searchDTO);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> CancelAuctionOfItem(int? id)
        {
            if (id == null) return BadRequest();

            await _itemService.CancelAuctionAsync((int)id);
            return RedirectToAction("Index", "Item", new { area = "" });
        }
    }
}