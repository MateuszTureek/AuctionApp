using AuctionApp.Core.BLL.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.ViewComponents
{
    public class Category : ViewComponent
    {
        readonly ICategoryService _service;

        public Category(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dto = _service.GetCategories();
            return View(dto);
        }
    }
}
