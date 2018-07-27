using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers
{
    [Authorize(Roles = Role.customer)]
    [Area("customer")]
    public class HomeController : Controller
    {
        readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Contact()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dto = _customerService.GetContact(userId);
            return View(dto);
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}