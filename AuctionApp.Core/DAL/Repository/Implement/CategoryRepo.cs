using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Contract
{
    public class CategoryRepo : ICategoryRepo
    {
        readonly AuctionDbContext _dbContext;

        public CategoryRepo(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category category)
        {
            _dbContext.Categories.Add(category);
        }

        public void AddSubcategory(int categoryId, Subcategory subcategory)
        {
            _dbContext.Categories.Find(categoryId).Subcategories.Add(subcategory);
        }

        public IEnumerable<Category> All()
        {
            return _dbContext.Categories.AsEnumerable();
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void Remove(Category category)
        {
            _dbContext.Categories.Remove(category);
        }
    }
}
