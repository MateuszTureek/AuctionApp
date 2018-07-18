using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.Service.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Areas.customer.ViewComponents
{
    public class NewItem : ViewComponent
    {
        readonly IDeliveryService _deliveryService;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;

        public NewItem(IDeliveryService deliveryService, ICategoryService categoryService, IMapper mapper)
        {
            _deliveryService = deliveryService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var deliveryMethods = _deliveryService.GetAllMethods();
            var categories = _categoryService.GetCategories();
            var subcategories = categories.First().Subcategories.ToList();

            NewItemViewModel model = new NewItemViewModel
            {
                ConstPrice = 0.00M,
                Name = "",
                DeliverMethods = deliveryMethods.Select(s => new SelectListItem(s.Name, s.Id + "")).ToList(),
                Categories = categories.Select(s => new SelectListItem(s.Name, s.Id + "")).ToList(),
                Subcategories = subcategories.Select(s => new SelectListItem(s.Name, s.Id + "")).ToList()
            };

            return View(model);
        }
    }
}