using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Order;

namespace AuctionApp.Core.BLL.Service.Contract {
    public interface IOrderService {
        Task CreateOrderAsync (CreatedOrderDTO dto);
        decimal GetTotalLiabilities (string userId);
    }
}