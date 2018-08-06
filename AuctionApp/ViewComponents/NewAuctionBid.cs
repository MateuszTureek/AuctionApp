using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.ViewComponents {
    [ViewComponent]
    public class NewAuctionBid : ViewComponent {
        readonly IMapper _mapper;
        readonly IItemService _itemService;

        public NewAuctionBid (IMapper mapper, IItemService itemService) {
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync (int id) {
            var bestBid = await _itemService.GetBestBidAsync (id);
            NewBidViewModel model = _mapper.Map<NewBidDTO, NewBidViewModel> (bestBid);
            return View (model);
        }
    }
}