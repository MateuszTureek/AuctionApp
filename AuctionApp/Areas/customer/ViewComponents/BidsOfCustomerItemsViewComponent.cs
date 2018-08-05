using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.ViewComponents {
    public class BidsOfCustomerItemsViewComponent : ViewComponent {
        readonly IItemService _itemService;

        public BidsOfCustomerItemsViewComponent (IItemService itemService) {
            _itemService = itemService;
        }

        public async Task<IViewComponentResult> InvokeAsync () {
            var userId = UserClaimsPrincipal.FindFirst (ClaimTypes.NameIdentifier).Value;
            var dto = _itemService.GetShortMyAuctions (userId);
            return View (dto);
        }
    }
}