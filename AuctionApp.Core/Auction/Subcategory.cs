using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.Auction
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public Category Category { get; set; }
        public IList<Item> Items { get; set; }
    }
}
