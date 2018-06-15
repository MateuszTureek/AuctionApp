using AuctionApp.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.IRepo
{
    public interface ICategoryRepo
    {
        void Add(Category category);
        void Remove(Category category);
        IEnumerable<Category> All();
        Category Get(int id);
        void AddSubcategory(int categoryId, Subcategory subcategory);
    }
}
