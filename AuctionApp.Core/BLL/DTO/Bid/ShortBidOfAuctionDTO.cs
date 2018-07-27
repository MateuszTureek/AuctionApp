using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Bid
{
    public class ShortBidOfAuctionDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal BidPrice { get; set; }
        public string Username { get; set; }
        public DateTime PlacedDate { get; set; }
    }
}
