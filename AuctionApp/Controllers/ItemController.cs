using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Criteria;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class ItemController : Controller
    {
        readonly int pageSize = 3;
        readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        public IActionResult Index(int? categoryId,
                                   int? subcategoryId,
                                   int? amountOfPagingLink,
                                   int pageNumber = 1,
                                   SortBy sortBy = SortBy.Name)
        {
            ViewBag.CategoryId = categoryId;
            ViewBag.SortBy = sortBy;
            ViewBag.PageNumber = pageNumber;
            ViewBag.SubcategoryId = subcategoryId;

            int amountOfPages = 0;

            var result = _service.GetItems(new ItemCriteria()
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
                SortBy = sortBy,
                CategoryId = categoryId,
                SubcategoryId = subcategoryId,
                Status = Status.InAuction
            }, out amountOfPages);

            ViewBag.AmountOfPagingLink = (int)Math.Ceiling((double)amountOfPages / pageSize);

            return View(result);
        }

        public IActionResult Search(string phrase)
        {
            ViewBag.Phrase = phrase;

            var result = _service.SearchItems(phrase);

            return View(result);
        }

        public IActionResult Item(int? id)
        {
            return View(
                _service.GetItem((int)id));
        }
    }
}