using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Item
    {
        public Item()
        {
            Bids = new List<Bid>();
            ItemDescriptions = new List<ItemDescription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgSrc { get; set; }
        public decimal ConstPrice { get; set; }
        public Status Status { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public DateTime? AuctionStart { get; set; }
        public DateTime? AuctionEnd { get; set; }
        #region Navigation properties
        public int? SubcategoryRef { get; set; }
        public Subcategory Subcategory { get; set; }

        public int? PaymentRef { get; set; }
        public Payment Payment { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public List<Bid> Bids { get; }
        public List<ItemDescription> ItemDescriptions { get; }
        #endregion
        #region Methods
        public void AddDescription(ItemDescription description)
        {
            ItemDescriptions.Add(description);
        }

        public void AddDescriptions(List<ItemDescription> descriptions)
        {
            ItemDescriptions.AddRange(descriptions);
        }

        public void AddBid(Bid bid)
        {
            Bids.Add(bid);
        }

        public void ClearBids()
        {
            Bids.Clear();
        }
        #endregion
    }
}
