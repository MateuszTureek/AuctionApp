﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AutoMapper;

namespace AuctionApp.Core.BLL.Service.Implement {
    public class CategoryService : ICategoryService {
        readonly IMapper _mapper;
        readonly ICategoryRepo _categoryRepo;

        public CategoryService (IMapper mapper,
            ICategoryRepo categoryRepo) {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public List<CategoryDTO> GetCategories () {
            var categories = _categoryRepo.GetAll ().ToList ();
            return _mapper.Map<List<Category>, List<CategoryDTO>> (categories);
        }

        public async Task<CategoryDTO> GetCategoryAsync (int id) {
            var category = await _categoryRepo.GetById (id);
            return _mapper.Map<Category, CategoryDTO> (category);
        }
    }
}