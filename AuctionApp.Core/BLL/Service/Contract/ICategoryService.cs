using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
    }
}
