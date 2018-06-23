using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Static;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class ItemController : Controller
    {
        readonly int pageSize = PaginationService.PageSize;
        readonly IItemService _service;
        readonly IPaginationService _paginationService;

        public ItemController(IItemService service, IPaginationService paginationService)
        {
            _paginationService = paginationService;
            _service = service;
        }

        public IActionResult Index(int? categoryId,
                                   int? subcategoryId,
                                   int? amountOfPagiingLink,
                                   int pageNumber = 1,
                                   SortBy sortBy = SortBy.Name)
        {
            ViewBag.CategoryId = categoryId;
            ViewBag.SortBy = sortBy;
            ViewBag.PageNumber = pageNumber;
            ViewBag.SubcategoryId = subcategoryId;

            var result = _service.GetItems(new FilterItemDTO
            {
                CategoryId = categoryId,
                SubcategoryId = subcategoryId,
                SortBy = sortBy,
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            if (pageNumber <= 1 && result != null)
                ViewBag.AmountOfPagiingLink = _paginationService.AmountOfPages();
            else
                ViewBag.AmountOfPagiingLink = amountOfPagiingLink;

            return View(result);
        }
        
        public IActionResult Search(string phrase)
        {
            var result = _service.SearchItems(phrase);
            ViewBag.Phrase = phrase;

            return View(result);
        }

        public IActionResult Item(int? id)
        {
            return View(
                _service.GetItem((int)id));
        }
    }
}