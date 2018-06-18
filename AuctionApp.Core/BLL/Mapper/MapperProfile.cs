using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Configure();
        }

        public void Configure()
        {
            CreateMap<Item, LatestAuctionDTO>();
            CreateMap<Item, AuctionDTO>();
            CreateMap<ItemDescription, DescriptionDTO>();
            CreateMap<Subcategory, SubcategoryDTO>();
            CreateMap<Category, CategoryDTO>().ForMember(d => d.Subcategories, o => o.MapFrom(m => m.Subcategories.ToList()));
        }
    }
}
