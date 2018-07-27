using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionApp.Areas.customer.ViewComponents
{
    public class CustomerInfoViewComponent : ViewComponent
    {
        readonly ICustomerService _customerService;

        public CustomerInfoViewComponent(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dto = _customerService.GetContact(userId);

            return View(dto);
        }
    }
}