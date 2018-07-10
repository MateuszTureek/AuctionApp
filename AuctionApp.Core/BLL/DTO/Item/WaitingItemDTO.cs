using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class WaitingItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BuyNowPrice { get; set; }
        public string CategoryName { get; set; }
        public string DeliveryMethod { get; set; }
    }
}
