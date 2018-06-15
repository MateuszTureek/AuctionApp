using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Data.AuctionContext.Domain
{
    public class ClientBid
    {
        public int BidId { get; set; }
        public Bid Bid { get; set; }

        public string UserId { get; set; }
    }
}
