using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class BidOfAuction
    {
        public decimal BidAmount { get; set; }
        public DateTime DatePlaced { get; set; }
        public string UserName { get; set; }
    }
}
