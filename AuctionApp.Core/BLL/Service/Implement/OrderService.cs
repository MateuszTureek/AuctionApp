﻿using AuctionApp.Core.BLL.DTO.Order;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class OrderService : IOrderService
    {
        readonly IItemRepo _itemRepo;
        readonly IOrderRepo _orderRepo;
        readonly IUnitOfWork _unitOfWork;
        readonly IItemService _itemService;

        public OrderService(IItemRepo itemRepo, IOrderRepo orderRepo, IUnitOfWork unitOfWork)
        {
            _itemRepo = itemRepo;
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
        }

        public void CreateOrder(CreatedOrderDTO dto)
        {
            var cartItems = dto.OrderItems;
            var buyerId = dto.UserId;
            List<Item> items = new List<Item>();
            Item item;
            int i, length = cartItems.Count;
            decimal totalSum = 0;

            for (i = 0; i < length; i += 1)
            {
                item = _itemRepo.GetById(cartItems[i].ItemId);
                item.Status = Status.Bought;
                items.Add(item);
            }

            totalSum = cartItems.Sum(s => s.Price + s.DeliveryCost);

            Order order = new Order
            {
                BuyerId = buyerId,
                Date = DateTime.Now,
                TotalCost = totalSum,
                Items = items
            };

            _orderRepo.Add(order);
            _unitOfWork.Save();
        }
    }
}
