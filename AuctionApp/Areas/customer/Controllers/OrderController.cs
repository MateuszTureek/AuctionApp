using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Cart;
using AuctionApp.Core.BLL.DTO.Order;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Areas.customer.Controllers {
    [Area ("customer")]
    [Authorize (Roles = Role.customer)]
    public class OrderController : Controller {
        readonly ICartService _cartService;
        readonly IOrderService _orderService;
        readonly IMapper _mapper;

        public OrderController (ICartService cartService, IOrderService orderService, IMapper mapper) {
            _cartService = cartService;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder () {
            string userId = User.FindFirst (ClaimTypes.NameIdentifier).Value;
            List<CartItemDTO> cart = _cartService.GetCartItems ();
            CreatedOrderDTO dto = new CreatedOrderDTO {
                UserId = userId,
                OrderItems = _mapper.Map<List<CartItemDTO>, List<CreatedOrderItemDTO>> (cart)
            };
            await _orderService.CreateOrderAsync (dto);
            await _cartService.RemoveCart ();
            return RedirectToAction ("Index", "Home", new { area = "" });
        }
    }
}