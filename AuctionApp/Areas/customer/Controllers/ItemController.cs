using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.DTO.Auction;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Area("customer")]
    [Authorize(Roles = Role.customer)]
    public class ItemController : Controller
    {
        readonly IMapper _mappper;
        readonly IItemService _itemService;
        readonly IPhotoService _photoService;

        public ItemController(IItemService itemService,IMapper mapper, IPhotoService photoService)
        {
            _itemService = itemService;
            _mappper = mapper;
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(NewItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                string username = User.FindFirst(ClaimTypes.Name).Value;
                _photoService.AddPhoto(model.File);

                NewItemDTO dto = _mappper.Map<NewItemViewModel, NewItemDTO>(model);
                dto.ImgSrc = _photoService.GetFilePath(model.File);

                _itemService.Create(dto, userId, username);

                return RedirectToAction("Index", "Manage", new { area = "customer" });
            }
            ModelState.AddModelError(string.Empty, "Niepoprawne dane produktu.");
            return View(model);
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
            SearchCriteriaDTO searchDTO,
            WaitingItemsOrderBy orderBy = WaitingItemsOrderBy.Name)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _itemService.GetWaitingItems(orderBy, searchDTO, userId);
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetInAuctionItems(
            SearchCriteriaDTO searchDTO,
            InAuctionItemsOrderBy orderBy = InAuctionItemsOrderBy.Name)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _itemService.GetInAuctionItems(orderBy, searchDTO, userId);
            return Json(result);
        }

        [HttpGet]
        public IActionResult GetBoughtItems(
            SearchCriteriaDTO searchDTO,
            BoughtItemsOrderBy orderBy = BoughtItemsOrderBy.Name)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _itemService.GetBoughtItems(orderBy, searchDTO, userId);
            return Json(result);
        }
    }
}