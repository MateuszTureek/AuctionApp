using AuctionApp.Core.BLL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Bid
{
    public class CustomerShortBidDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal CurrentOffer { get; set; }
        public decimal MyOfferPrice { get; set; }
        public BidState BidState { get; set; }
    }
}
