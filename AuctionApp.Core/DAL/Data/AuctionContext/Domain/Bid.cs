using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime DatePlaced { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }

        public int? ItemRef { get; set; }
        public Item Item { get; set; }
    }
}
