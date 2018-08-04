using System;
using System.Collections.Generic;
using System.Text;
using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;

namespace AuctionApp.Core.BLL.Service.Contract {
    public interface ICategoryService {
        List<CategoryDTO> GetCategories ();
        CategoryDTO GetCategory (int id);
    }
}