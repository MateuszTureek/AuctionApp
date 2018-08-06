using AuctionApp.Areas.customer.Models;
using AuctionApp.Areas.customer.Models.Item;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Customer;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Models;
using AuctionApp.Models.Account;
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
            CreateMap<ContactDTO, ContactViewModel>()
                .ForMember(d => d.PhotoSrc, o => o.MapFrom(m => m.Photo));
            CreateMap<ContactViewModel, ContactDTO>()
                .ForMember(d => d.Photo, o => o.MapFrom(m => m.PhotoSrc));

            CreateMap<NewItemViewModel, NewItemDTO>()
                .ForMember(d => d.PaymentId, o => o.MapFrom(m => m.PayId));

            CreateMap<NewBidViewModel, NewBidDTO>();
            CreateMap<NewBidDTO,NewBidViewModel>();
            CreateMap<ItemDetailsDTO, ItemDetailsViewModel>();
            CreateMap<ItemBidDTO, Areas.customer.Models.ItemBidViewModel>();
            CreateMap<SimpleItemDTO, SimpleItemViewModel>();
            CreateMap<PagedItemDTO, PagedItemViewModel>();
            CreateMap<PagedItemCriteriaViewModel, PagedItemCriteriaDTO>();
            CreateMap<CreateAuctionViewModel, CreateAuctionDTO>();
            CreateMap<ItemBidDTO, Areas.customer.Models.ItemBidViewModel>();
            CreateMap<ItemAuctionDTO, ItemAuctionViewModel>();
            CreateMap<RegisterViewModel,AppUser>();
        }
    }
}
