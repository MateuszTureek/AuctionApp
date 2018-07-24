using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class ItemController : Controller
    {
        readonly int pageSize = 20;
        readonly IItemService _service;
        readonly IMapper _mapper;

        public ItemController(IItemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(PagedItemCriteriaViewModel criteria)
        {
            if (criteria.PageNumber == null) criteria.PageNumber = 1;

            ViewBag.CategoryId = criteria.CategoryId;
            ViewBag.SortBy = criteria.SortBy;
            ViewBag.PageNumber = criteria.PageNumber;
            ViewBag.SubcategoryId = criteria.SubcategoryId;

            PagedItemCriteriaDTO criteriaDTO = _mapper.Map<PagedItemCriteriaViewModel, PagedItemCriteriaDTO>(criteria);
            criteriaDTO.PageSize = pageSize;
            criteriaDTO.Status = Status.InAuction;

            var dto = _service.GetItems(criteriaDTO);
            var model = _mapper.Map<PagedItemDTO, PagedItemViewModel>(dto);

            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string phrase)
        {
            ViewBag.Phrase = phrase;

            var result = _service.SearchItems(phrase);

            return View(result);
        }

        [HttpGet]
        public IActionResult Item(int? id)
        {
            if (id == null) return BadRequest();
            ItemDetailsDTO item = _service.GetItem((int)id);
            ItemDetailsViewModel model = _mapper.Map<ItemDetailsDTO, ItemDetailsViewModel>(item);
            model.Bids = model.Bids.OrderByDescending(o => o.BidAmount).ToList();
            return View(model);
        }
    }
}