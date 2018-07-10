using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
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

        public async Task<IViewComponentResult> InvokeAsync(Status status)
        {
            var dto = _service.GetLastAddedItems(status);
            return View(dto);
        }
    }
}
