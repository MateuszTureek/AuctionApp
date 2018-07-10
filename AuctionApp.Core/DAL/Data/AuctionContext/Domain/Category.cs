using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public IList<Subcategory> Subcategories { get; set; }

        public void AddSubcategory(Subcategory subcategory)
        {
            if (Subcategories != null) Subcategories.Add(subcategory);
            else throw new NullReferenceException();
        }
    }
}
