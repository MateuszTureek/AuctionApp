using System.Collections.Generic;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Category
    {
        public Category()
        {
            Subcategories = new List<Subcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public List<Subcategory> Subcategories { get; }

        public void AddSubcategory(Subcategory subcategory)
        {
            Subcategories.Add(subcategory);
        }
    }
}
