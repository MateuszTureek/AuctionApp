using AuctionApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.Auction
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
