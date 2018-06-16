using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        readonly IMapper _mapper;
        readonly ICategoryRepo _categoryRepo;

        public CategoryService(IMapper mapper,
                               ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public List<CategoryDTO> GetCategories()
        {
            var categories = _categoryRepo.All().ToList();
            return _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
        }

        public CategoryDTO GetCategory(int id)
        {
            var category = _categoryRepo.GetById(id);
            return _mapper.Map<Category, CategoryDTO>(category);
        }
    }
}
