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
            CreateMap<Item, LatestItemDTO>();
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDescription, DescriptionDTO>();
            CreateMap<Subcategory, SubcategoryDTO>();
            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.Subcategories, o => o.MapFrom(m => m.Subcategories.ToList()));
            CreateMap<Bid, BidOfAuction>();
            CreateMap<Item, SingleItemDTO>()
                .ForMember(d => d.Bids, o => o.MapFrom(m => m.Bids))
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(m => m.Payment.Name));
            CreateMap<SingleItemDTO, CartItemDTO>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Name))
                .ForMember(d => d.Price, o => o.MapFrom(m => m.BuyNowPrice))
                .ForMember(d => d.ImgSrc, o => o.MapFrom(m => m.ImgSrc));
        }
    }
}
