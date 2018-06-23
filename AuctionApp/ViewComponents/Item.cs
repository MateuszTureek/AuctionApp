using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.ViewComponents
{
    public class Item : ViewComponent
    {
        readonly IItemService _service;

        public Item(IItemService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool activated)
        {
            var dto = _service.TakeItems(3, activated);
            return View(dto);
        }
    }
}
