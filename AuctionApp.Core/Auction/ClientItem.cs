using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.Auction
{
    public class ClientItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string UserId { get; set; }
    }
}
