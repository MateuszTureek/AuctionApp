using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Data.AuctionContext.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public IList<Subcategory> Subcategories { get; set; }
    }
}
