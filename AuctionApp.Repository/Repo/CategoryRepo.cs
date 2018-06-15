using AuctionApp.Core.AuctionContext;
using AuctionApp.Core.AuctionContext.Domain;
using AuctionApp.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.Repo
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

        public Category Get(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void Remove(Category category)
        {
            _dbContext.Categories.Remove(category);
        }
    }
}
