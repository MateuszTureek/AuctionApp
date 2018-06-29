using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class EndedItem : ItemDTO
    {
        public DateTime AuctionEndDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal DeliveryCost { get; set; }
        public string BuyerName { get; set; }
        public decimal PriceOfItem { get; set; }
        public decimal TitalPrice { get; set; }
    }
}
