using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.ViewComponents
{
    public class Auction : ViewComponent
    {
        readonly IAuctionService _service;

        public Auction(IAuctionService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool activated)
        {
            var dto = _service.TakeAuctions(3, activated);
            return View(dto);
        }
    }
}
