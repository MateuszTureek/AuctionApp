using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Areas.customer.Models;
using AuctionApp.Core.BLL.DTO.Customer;
using AuctionApp.Core.BLL.Service.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.ViewComponents {
    public class EditContactViewComponent : ViewComponent {
        readonly ICustomerService _customerService;
        readonly IMapper _mapper;

        public EditContactViewComponent (ICustomerService customerService, IMapper mapper) {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync () {
            var userId = UserClaimsPrincipal.FindFirst (ClaimTypes.NameIdentifier).Value;
            var dto = _customerService.GetContact (userId);
            var model = _mapper.Map<ContactDTO, ContactViewModel> (dto);
            return View (model);
        }
    }
}