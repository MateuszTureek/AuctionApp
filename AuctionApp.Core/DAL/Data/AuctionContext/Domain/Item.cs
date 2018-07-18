using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgSrc { get; set; }
        public decimal ConstPrice { get; set; }
        public Status Status { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

        public int? AuctionRef { get; set; }
        public Auction Auction { get; set; }

        public int? SubcategoryRef { get; set; }
        public Subcategory Subcategory { get; set; }

        public int? DeliveryRef { get; set; }
        public Delivery Delivery { get; set; }

        public IList<ItemDescription> ItemDescriptions { get; set; }

        public void AddDescription(ItemDescription description)
        {
            if (description != null) ItemDescriptions.Add(description);
            else throw new NullReferenceException();
        }
    }
}
