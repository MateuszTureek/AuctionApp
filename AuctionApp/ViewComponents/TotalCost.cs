using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.ViewComponents
{
    public class TotalCost : ViewComponent
    {
        readonly ICartService _service;

        public TotalCost(ICartService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalCost = _service.GetTotalPrice();
            return Content(string.Format(new System.Globalization.CultureInfo("pl"), "{0:C}", _service.GetTotalPrice()));
        }
    }
}
