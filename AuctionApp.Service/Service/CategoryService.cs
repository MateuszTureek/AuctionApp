using AuctionApp.Data.AuctionContext.Domain;
using AuctionApp.Repository.IRepo;
using AuctionApp.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Service.Service
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepo _repository;

        public CategoryService(ICategoryRepo repo)
        {
            _repository = repo;
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
