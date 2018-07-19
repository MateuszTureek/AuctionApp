using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Order
{
    public class CreatedOrderItemDTO
    {
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryCost { get; set; }
    }
}
