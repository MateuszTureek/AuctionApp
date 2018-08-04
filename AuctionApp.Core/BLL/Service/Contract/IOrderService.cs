using System;
using System.Collections.Generic;
using System.Text;
using AuctionApp.Core.BLL.DTO.Order;

namespace AuctionApp.Core.BLL.Service.Contract {
    public interface IOrderService {
        void CreateOrder (CreatedOrderDTO dto);
        decimal GetTotalLiabilities (string userId);
    }
}