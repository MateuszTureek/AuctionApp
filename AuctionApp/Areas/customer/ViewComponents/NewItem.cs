using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Repository.Contract;
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
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        readonly IPaymentRepo _paymentRepo;

        public NewItem(ICategoryService categoryService, IMapper mapper, IPaymentRepo paymentRepo)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _paymentRepo = paymentRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryService.GetCategories();
            var subcategories = categories.First().Subcategories.ToList();
            var payments = _paymentRepo.GetAll();

            NewItemViewModel model = new NewItemViewModel
            {
                ConstPrice = 0.00M,
                Name = "",
                Categories = categories.Select(s => new SelectListItem(s.Name, s.Id + "")).ToList(),
                Subcategories = subcategories.Select(s => new SelectListItem(s.Name, s.Id + "")).ToList(),
                Payments = payments.Select(s => new SelectListItem(s.Name, s.Id + "")).ToList()
            };

            return View(model);
        }
    }
}