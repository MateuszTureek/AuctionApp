using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.DTO.Item;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Configure();
        }

        public void Configure()
        {
            CreateMap<NewItemViewModel, NewItemDTO>();
        }
    }
}
