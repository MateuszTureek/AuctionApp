using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Cart;
using AuctionApp.Core.BLL.DTO.Customer;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.DTO.Order;
using AuctionApp.Core.BLL.Mapper.Resolver;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AutoMapper;
using System.Linq;

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
            CreateMap<Bid, ShortBidOfAuctionDTO>()
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Item.Id))
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Item.Name))
                .ForMember(d => d.BidPrice, o => o.MapFrom(m => m.BidAmount))
                .ForMember(d => d.PlacedDate, o => o.MapFrom(m => m.DatePlaced))
                .ForMember(d => d.Username, o => o.MapFrom(m => m.Username));

            CreateMap<Bid, CustomerShortBidDTO>()
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Item.Id))
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Item.Name))
                .ForMember(d => d.MyOfferPrice, o => o.MapFrom(m => m.BidAmount))
                .ForMember(d => d.BidState, o => o.ResolveUsing<BidStateResolver<CustomerShortBidDTO>>());

            CreateMap<AppUser, ContactDTO>()
                .ForMember(d => d.Phone, o => o.MapFrom(m => m.PhoneNumber))
                .ForMember(d => d.Photo, o => o.MapFrom(m => m.PhotoSrc))
                .ForMember(d => d.UserId, o => o.MapFrom(m => m.Id));

            CreateMap<ContactDTO, AppUser>();

            CreateMap<Bid,BidDetailsDTO>()
                .ForMember(d=>d.ItemId,o=>o.MapFrom(m=>m.Item.Id))
                .ForMember(d=>d.ItemName,o=>o.MapFrom(m=>m.Item.Name))
                .ForMember(d=>d.ImgSrc,o=>o.MapFrom(m=>m.Item.ImgSrc))
                .ForMember(d=>d.BuyNowPrice,o=>o.MapFrom(m=>m.Item.ConstPrice))
                .ForMember(d=>d.OwnerUsername,o=>o.MapFrom(m=>m.Item.Username))
                .ForMember(d=>d.Subcategory,o=>o.MapFrom(m=>m.Item.Subcategory.Name))
                .ForMember(d=>d.Payment,o=>o.MapFrom(m=>m.Item.Payment.Name))
                .ForMember(d=>d.PaymentCost,o=>o.MapFrom(m=>m.Item.Payment.Cost))
                .ForMember(d=>d.AuctionStart,o=>o.MapFrom(m=>m.Item.AuctionStart))
                .ForMember(d=>d.AuctionEnd,o=>o.MapFrom(m=>m.Item.AuctionEnd))
                .ForMember(d=>d.MyOfferPrice,o=>o.MapFrom(m=>m.BidAmount))
                .ForMember(d=>d.MyOfferPlaced,o=>o.MapFrom(m=>m.DatePlaced));

            CreateMap<Item, ItemAuctionDTO>()
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Name))
                .ForMember(d => d.Payment, o => o.MapFrom(m => m.Payment.Name))
                .ForMember(d => d.PriceBuyNow, o => o.MapFrom(m => m.ConstPrice));

            CreateMap<Bid, ItemBidDTO>();

            CreateMap<Payment, PaymentDTO>();

            CreateMap<Item, ItemDTO>()
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.Id, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.ImgSrc, o => o.MapFrom(m => m.ImgSrc))
                .ForMember(d => d.Name, o => o.MapFrom(m => m.Name));

            CreateMap<Item, SimpleItemDTO>()
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.Payment, o => o.MapFrom(m => m.Payment.Name));

            CreateMap<Item, ItemDetailsDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.Descriptions, o => o.MapFrom(m => m.ItemDescriptions))
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.Payment, o => o.MapFrom(m => m.Payment.Name))
                .ForMember(d => d.Bids, o => o.MapFrom(m => m.Bids))
                .ForMember(d => d.UsernameOfOwner, o => o.MapFrom(m => m.Username));

            CreateMap<Item, WaitingItemDTO>()
                .ForMember(o => o.CategoryName, d => d.MapFrom(m => m.Subcategory.Category.Name))
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(o => o.Payment, d => d.MapFrom(m => m.Payment.Name));

            CreateMap<Item, InAuctionItemDTO>()
                .ForMember(o => o.Payment, d => d.MapFrom(m => m.Payment.Name))
                .ForMember(o => o.BuyNowPrice, d => d.MapFrom(m => m.ConstPrice))
                .ForMember(o => o.CategoryName, d => d.MapFrom(m => m.Subcategory.Category.Name))
                .ForMember(d => d.AuctionStartDateMiliseconds, o => o.ResolveUsing<AuctionStartDateResolver<InAuctionItemDTO>>())
                .ForMember(d => d.AuctionEndDateMiliseconds, o => o.ResolveUsing<AuctionEndDateResolver<InAuctionItemDTO>>());

            CreateMap<Item, CartItemDTO>()
                .ForMember(d => d.Price, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Name))
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Id))
                .ForMember(d => d.ImgSrc, o => o.MapFrom(m => m.ImgSrc));

            CreateMap<NewItemDTO, Item>()
                .ForMember(d => d.Payment, o => o.Ignore())
                .ForMember(d => d.PaymentRef, o => o.Ignore())
                .ForMember(d => d.Status, o => o.Ignore())
                .ForMember(d => d.SubcategoryRef, o => o.Ignore());

            CreateMap<Item, NewItemDTO>();

            CreateMap<Bid, NewBidDTO>()
                .ForMember(d => d.BestBidPrice, o => o.MapFrom(m => m.BidAmount))
                .ForMember(d => d.MyBid, o => o.Ignore());

            CreateMap<ItemDescription, DescriptionDTO>();
            CreateMap<DescriptionDTO, ItemDescription>();

            CreateMap<Item, BoughtItemDTO>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(m => m.Subcategory.Category.Name))
                .ForMember(d => d.BuyNowPrice, o => o.MapFrom(m => m.ConstPrice))
                .ForMember(d => d.AuctionStartDateMiliseconds, o => o.ResolveUsing<AuctionStartDateResolver<BoughtItemDTO>>())
                .ForMember(d => d.AuctionEndDateMiliseconds, o => o.ResolveUsing<AuctionEndDateResolver<BoughtItemDTO>>())
                .ForMember(d => d.PaymentPrice, o => o.MapFrom(m => m.Payment.Cost))
                .ForMember(d => d.Payment, o => o.MapFrom(m => m.Payment.Name))
                .ForMember(d => d.TotalCost, o => o.MapFrom(m => m.Order.TotalCost))
                .ForMember(d => d.BuyerId, o => o.MapFrom(m => m.Order.BuyerId));

            CreateMap<Subcategory, SubcategoryDTO>();

            CreateMap<Category, CategoryDTO>()
                .ForMember(d => d.Subcategories, o => o.MapFrom(m => m.Subcategories.ToList()));

            CreateMap<Bid, BidOfAuctionDTO>();

            CreateMap<Bid, CustomerBidDTO>()
                .ForMember(d => d.BidId, o => o.MapFrom(m => m.Id))
                .ForMember(d=>d.AuctionStart,o=>o.MapFrom(m=>m.Item.AuctionStart))
                .ForMember(d => d.AuctionEnd, o => o.MapFrom(m => m.Item.AuctionEnd))
                .ForMember(d => d.ItemName, o => o.MapFrom(m => m.Item.Name))
                .ForMember(d => d.ItemImg, o => o.MapFrom(m => m.Item.ImgSrc))
                .ForMember(d => d.MyOfferPrice, o => o.MapFrom(m => m.BidAmount))
                .ForMember(d => d.DateOfPlaced, o => o.MapFrom(m => m.DatePlaced))
                .ForMember(d => d.ItemId, o => o.MapFrom(m => m.Item.Id))
                .ForMember(d => d.BidState, o => o.ResolveUsing<BidStateResolver<CustomerBidDTO>>());

            CreateMap<CartItemDTO, CreatedOrderItemDTO>();
        }
    }
}