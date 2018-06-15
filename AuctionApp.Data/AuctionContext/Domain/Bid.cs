using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Data.AuctionContext.Domain
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime DatePlaced { get; set; }
        public Item Item { get; set; }

        public IList<ClientBid> ClientBids { get; set; }
    }
}
