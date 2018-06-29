using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.DTO.Item;
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

            CreateMap<Item, SimpleItemDTO>()
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(m => m.Payment.Name));

            CreateMap<Item, ItemDetailsDTO>()
                .ForMember(d => d.Bids, o => o.MapFrom(m => m.Bids))
                .ForMember(d => d.Descriptions, o => o.MapFrom(m => m.Descriptions))
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(m => m.Payment.Name));

            CreateMap<ItemDetailsDTO, CartItemDTO>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Name))
                .ForMember(d => d.Price, o => o.MapFrom(m => m.BuyNowPrice))
                .ForMember(d => d.ImgSrc, o => o.MapFrom(m => m.ImgSrc));

            CreateMap<ItemDescription, DescriptionDTO>();

            CreateMap<Subcategory, SubcategoryDTO>();

            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.Subcategories, o => o.MapFrom(m => m.Subcategories.ToList()));

            CreateMap<Bid, BidOfAuction>();
        }
    }
}
