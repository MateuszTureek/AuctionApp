using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Bid
{
    public class ItemBidDTO
    {
        public decimal BidAmount { get; set; }
        public DateTime DatePlaced { get; set; }
        public string Username { get; set; }
    }
}
