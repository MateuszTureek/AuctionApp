using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Areas.customer.Models;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Area("customer")]
    [Authorize(Roles = Role.customer)]
    public class BidController : Controller
    {
        readonly IItemService _itemService;
        readonly IMapper _mapper;

        public BidController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dto = _itemService.GetCustomerBestBids(userId);
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();
            var bidDTO = await _itemService.GetBidDetailsAsync((int)id);
            var model = _mapper.Map<BidDetailsDTO, BidDetailsViewModel>(bidDTO);
            return View(model);
        }
    }
}