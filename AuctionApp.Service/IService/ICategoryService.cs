using AuctionApp.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Service.IService
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
    }
}
