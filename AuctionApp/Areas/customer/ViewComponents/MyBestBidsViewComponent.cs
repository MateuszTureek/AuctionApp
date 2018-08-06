using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.ViewComponents {
    public class MyBestBidsViewComponent : ViewComponent {
        readonly IItemService _itemService;

        public MyBestBidsViewComponent (IItemService itemService) {
            _itemService = itemService;
        }

        public async Task<IViewComponentResult> InvokeAsync () {
            var userId = UserClaimsPrincipal.FindFirst (ClaimTypes.NameIdentifier).Value;
            var dto = await _itemService.GetShortCustomerBestBidsAsync (userId);
            return View (dto);
        }
    }
}