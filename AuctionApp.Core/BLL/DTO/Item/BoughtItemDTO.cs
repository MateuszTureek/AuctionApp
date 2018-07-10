using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class BoughtItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal BuyNowPrice { get; set; }
        public double AuctionStartDateMiliseconds { get; set; }
        public double AuctionEndDateMiliseconds { get; set; }
        public string DeliveryMethod { get; set; }
        public string BuyerName { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal TotalCost { get; set; }
    }
}