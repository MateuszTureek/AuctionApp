using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionApp.Areas.customer.ViewComponents
{
    public class ActivitiesViewComponent : ViewComponent
    {
        public ActivitiesViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}