using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
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
            CreateMap<Item, AuctionDTO>();
            CreateMap<ItemDescription, DescriptionDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
