using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class ItemDescription
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public int ItemRef { get; set; }
        public Item Item { get; set; }
    }
}
