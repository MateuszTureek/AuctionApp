using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Areas.customer.Models;
using AuctionApp.Core.BLL.DTO.Customer;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers {
    [Authorize (Roles = Role.customer)]
    [Area ("customer")]
    public class CustomerController : Controller {
        readonly ICustomerService _customerService;
        readonly IMapper _mapper;

        public CustomerController (ICustomerService customerService, IMapper mapper) {
            _customerService = customerService;
            _mapper = mapper;
        }

        public IActionResult Contact () {
            var userId = User.FindFirst (ClaimTypes.NameIdentifier).Value;
            var dto = _customerService.GetContact (userId);
            return View (dto);
        }

        [HttpPost]
        public IActionResult EditContact (ContactViewModel model) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError (string.Empty, "Dane kontaktowe są niepoprawne.");
                return RedirectToAction ("Index", "Home", new { area = "customer" });
            }
            var dto = _mapper.Map<ContactViewModel, ContactDTO> (model);
            dto.UserId = User.FindFirst (ClaimTypes.NameIdentifier).Value;
            _customerService.EditContact (dto);
            return RedirectToAction ("Index", "Home", new { area = "customer" });
        }
    }
}