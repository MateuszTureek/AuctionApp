using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Data.AuctionContext.Domain
{
    public class ClientItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string UserId { get; set; }
    }
}
