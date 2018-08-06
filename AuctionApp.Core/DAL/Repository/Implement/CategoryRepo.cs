using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Implement;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Core.DAL.Repository.Contract {
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo {
        public CategoryRepo (AuctionDbContext db) : base (db) { }

        public void AddSubcategory (Category category, Subcategory subcategory) {
            category.Subcategories.Add (subcategory);
        }

        public override IEnumerable<Category> GetAll () {
            return _dbSet
                .Include (i => i.Subcategories)
                .AsNoTracking ()
                .AsEnumerable ();
        }

        public override async Task<Category> GetById (int id) {
            return await _dbSet
                .Include (i => i.Subcategories)
                .FirstOrDefaultAsync (f => f.Id == id);
        }

        public Subcategory GetSubcategory (int id) {
            var result = _dbSet.SelectMany (s => s.Subcategories).Include (i => i.Category).First (f => f.Id == id);
            return result;
        }
    }
}