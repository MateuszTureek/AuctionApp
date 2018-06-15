using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.AuctionContext.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Activated { get; set; }
        public DateTime AuctionEndDate { get; set; }
        public string ImgSrc { get; set; }
        public decimal BuyNowPrice { get; set; }

        public IList<Bid> Bids { get; set; }
        public IList<ItemDescription> Descriptions { get; set; }
        public Subcategory Subcategory { get; set; }
        public IList<ClientItem> ClientItems { get; set; }
    }
}
