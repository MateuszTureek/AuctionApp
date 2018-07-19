using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.DTO.Auction;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Cart;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.DTO.Order;
using AuctionApp.Core.BLL.Mapper.Resolver;
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
            CreateMap<Item, LatestItemDTO>()
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice));

            CreateMap<Item, SimpleItemDTO>()
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(m => m.Delivery.Name));

            CreateMap<Item, ItemDetailsDTO>()
                .ForMember(d => d.Descriptions, o => o.MapFrom(m => m.ItemDescriptions))
                .ForMember(d => d.Auction, o => o.MapFrom(m => m.Auction))
                .ForMember(d => d.Bids, o => o.MapFrom(m => m.Auction.Bids))
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(m => m.Delivery.Name));

            CreateMap<Item, CartItemDTO>()
                .ForMember(d => d.DeliveryName, o => o.MapFrom(m => m.Delivery.Name))
                .ForMember(d => d.DeliveryCost, o => o.MapFrom(m => m.Delivery.Price))
                .ForMember(d => d.Price, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Name))
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.ImgSrc, o => o.MapFrom(m => m.ImgSrc));

            CreateMap<ItemDescription, DescriptionDTO>();
            CreateMap<DescriptionDTO, ItemDescription>();

            CreateMap<Item, WaitingItemDTO>()
                .ForMember(o => o.CategoryName, d => d.MapFrom(m => m.Subcategory.Category.Name))
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(o => o.DeliveryMethod, d => d.MapFrom(m => m.Delivery.Name));

            CreateMap<Item, InAuctionItemDTO>()
                .ForMember(o => o.DeliveryMethod, d => d.MapFrom(m => m.Delivery.Name))
                .ForMember(o => o.BuyNowPrice, d => d.MapFrom(m => m.ConstPrice))
                .ForMember(o => o.CategoryName, d => d.MapFrom(m => m.Subcategory.Category.Name))
                .ForMember(d => d.AuctionStartDateMiliseconds, o => o.ResolveUsing<AuctionStartDateResolver<InAuctionItemDTO>>())
                .ForMember(d => d.AuctionEndDateMiliseconds, o => o.ResolveUsing<AuctionEndDateResolver<InAuctionItemDTO>>());

            CreateMap<Item, BoughtItemDTO>()
                .ForMember(o => o.DeliveryMethod, d => d.MapFrom(m => m.Delivery.Name))
                .ForMember(o => o.DeliveryPrice, d => d.MapFrom(m => m.Delivery.Price))
                .ForMember(d => d.CategoryName, o => o.MapFrom(m => m.Subcategory.Category.Name))
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.AuctionStartDateMiliseconds, o => o.ResolveUsing<AuctionStartDateResolver<BoughtItemDTO>>())
                .ForMember(d => d.AuctionEndDateMiliseconds, o => o.ResolveUsing<AuctionEndDateResolver<BoughtItemDTO>>())
                .ForMember(o => o.BuyPrice, d => d.ResolveUsing<AuctionBuyPriceResolver<BoughtItemDTO>>())
                .ForMember(o => o.BuyerName, d => d.ResolveUsing<AuctionBuyerNameResolver<BoughtItemDTO>>())
                .ForMember(o => o.TotalCost, d => d.ResolveUsing<AuctionTotalCostRevolver<BoughtItemDTO>>());

            CreateMap<Subcategory, SubcategoryDTO>();

            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.Subcategories, o => o.MapFrom(m => m.Subcategories.ToList()));

            CreateMap<Bid, BidOfAuctionDTO>();

            CreateMap<CreateAuctionDTO, Auction>()
                .ForMember(d => d.Item, o => o.Ignore())
                .ForMember(d => d.Bids, o => o.Ignore());

            CreateMap<Bid, BidOfAuctionDTO>();

            CreateMap<Item, AuctionDetailsDTO>()
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Name))
                .ForMember(d => d.PriceBuyNow, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.UserNameOfSeller, o => o.MapFrom(m => m.UserName))
                .ForMember(d => d.ImgSrc, o => o.MapFrom(m => m.ImgSrc))
                .ForMember(d => d.Delivery, o => o.MapFrom(m => m.Delivery.Name))
                .ForMember(d => d.StartDate, o => o.MapFrom(m => m.Auction.StartDate))
                .ForMember(d => d.EndDate, o => o.MapFrom(m => m.Auction.EndDate));

            CreateMap<NewItemDTO, Item>()
                .ForMember(d => d.Auction, o => o.Ignore())
                .ForMember(d => d.AuctionRef, o => o.Ignore())
                .ForMember(d => d.Delivery, o => o.Ignore())
                .ForMember(d => d.DeliveryRef, o => o.Ignore())
                .ForMember(d => d.Status, o => o.Ignore())
                .ForMember(d => d.SubcategoryRef, o => o.Ignore());

            CreateMap<CartItemDTO, CreatedOrderItemDTO>();
        }
    }
}