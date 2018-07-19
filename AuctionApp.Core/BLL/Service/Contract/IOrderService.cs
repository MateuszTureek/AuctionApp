using AuctionApp.Core.BLL.DTO.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IOrderService
    {
        void CreateOrder(CreatedOrderDTO dto);
    }
}
