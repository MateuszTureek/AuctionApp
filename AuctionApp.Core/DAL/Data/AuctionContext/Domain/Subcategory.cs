using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public int CategoryRef { get; set; }
        public Category Category { get; set; }

        public ICollection<Item> Items { get; set; }

        public void AddToSubcategory(Item item)
        {
            if (Items != null) Items.Add(item);
            else throw new NullReferenceException();
        }
    }
}
