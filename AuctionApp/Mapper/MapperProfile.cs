using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Models;
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
            CreateMap<NewItemViewModel, NewItemDTO>()
                .ForMember(d => d.PaymentId, o => o.MapFrom(m => m.PayId));

            CreateMap<NewBidViewModel, NewBidDTO>();
            CreateMap<NewBidDTO,NewBidViewModel>();
            CreateMap<ItemDetailsDTO, ItemDetailsViewModel>();
            CreateMap<ItemBidDTO, ItemBidViewModel>();
            CreateMap<SimpleItemDTO, SimpleItemViewModel>();
            CreateMap<PagedItemDTO, PagedItemViewModel>();
            CreateMap<PagedItemCriteriaViewModel, PagedItemCriteriaDTO>();
            CreateMap<CreateAuctionViewModel, CreateAuctionDTO>();
            CreateMap<ItemBidDTO, ItemBidViewModel>();
            CreateMap<ItemAuctionDTO, ItemAuctionViewModel>();
        }
    }
}
