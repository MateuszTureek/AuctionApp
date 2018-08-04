using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;

namespace AuctionApp.Core.DAL.Repository.Contract {
    public interface ICategoryRepo : IGenericRepo<Category> {
        void AddSubcategory (Category category, Subcategory subcategory);
        Subcategory GetSubcategory (int id);
    }
}