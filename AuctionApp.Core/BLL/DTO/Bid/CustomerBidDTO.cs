using AuctionApp.Core.BLL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Bid
{
    public class CustomerBidDTO
    {
        public int BidId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemImg { get; set; }
        public decimal MyOfferPrice { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public DateTime DateOfPlaced { get; set; }
        public BidState BidState { get; set; }
    }
}
