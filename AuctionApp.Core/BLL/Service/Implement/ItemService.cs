using AuctionApp.Core.BLL.Criteria;
using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.DTO.Auction;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Specyfication;
using AuctionApp.Core.DAL.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class ItemService : IItemService
    {
        readonly IMapper _mapper;
        readonly IItemRepo _itemRepo;
        readonly UserManager<AppUser> _userManager;
        readonly IUnitOfWork _unitOfWork;
        readonly ICategoryRepo _categoryRepo;
        readonly IGenericRepo<Delivery> _deliveryRepo;

        public ItemService(IMapper mapper, IItemRepo itemRepo, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IGenericRepo<Delivery> deliveryRepo, ICategoryRepo categoryRepo)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
            _userManager = userManager;
            _deliveryRepo = deliveryRepo;
            _categoryRepo = categoryRepo;
            _unitOfWork = unitOfWork;
        }

        public ItemDetailsDTO GetItem(int id)
        {
            var item = _itemRepo.GetById(id);
            var result = _mapper.Map<Item, ItemDetailsDTO>(item);
            
            return result;
        }

        public List<SimpleItemDTO> SearchItems(string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return new List<SimpleItemDTO>();

            CultureInfo culture = new CultureInfo("pl-PL");
            var items = _itemRepo.Find(x => x.Name.ToLower(culture).Contains(phrase.ToLower(culture))).ToList();

            return _mapper.Map<List<Item>, List<SimpleItemDTO>>(items);
        }

        public PagedItemDTO GetItems(ItemCriteria criteria)
        {
            var c = criteria;
            var spec = new FilterItemSpecyfication(c.Status, c.CategoryId, c.SubcategoryId);
            var orderSpec = new OrderItemSpecyfication(c.SortBy);
            var items = _itemRepo.Find(spec, orderSpec);
            var result = new PagedItemDTO();

            result.TotalPages = (int)Math.Ceiling((decimal)items.Count() / c.PageSize);
            items = items.Skip((c.PageIndex - 1) * c.PageSize).Take(c.PageSize).ToList();
            result.Items = _mapper.Map<List<Item>, List<SimpleItemDTO>>(items.ToList());

            return result;
        }

        public PagedWaitingItemsDTO GetWaitingItems(WaitingItemsOrderBy orderBy, SearchCriteriaDTO searchDTO, string userId)
        {
            var c = searchDTO;
            Expression<Func<Item, object>> oPredicate;

            if (string.IsNullOrEmpty(c.Phrase)) c.Phrase = "";

            switch (orderBy)
            {
                case WaitingItemsOrderBy.BuyNowPrice: { oPredicate = (x => x.ConstPrice); break; }
                case WaitingItemsOrderBy.Delivery: { oPredicate = (x => x.Delivery.Name); break; }
                default: { oPredicate = (x => x.Name); break; }
            }
            var items = _itemRepo.GetSortedItems(w => w.UserId == userId && w.Status == Status.Waiting && w.Name.Contains(c.Phrase), oPredicate);

            List<Item> list = items.Skip((c.PageIndex - 1) * c.AmountOfPages).Take(c.AmountOfPages).ToList();

            var result = new PagedWaitingItemsDTO()
            {
                TotalAmount = items.Count(),
                Items = _mapper.Map<List<Item>, List<WaitingItemDTO>>(list)
            };

            return result;
        }

        public PagedInAuctionItemsDTO GetInAuctionItems(InAuctionItemsOrderBy orderBy, SearchCriteriaDTO searchDTO, string userId)
        {
            var c = searchDTO;
            Expression<Func<Item, object>> oPredicate;

            if (string.IsNullOrEmpty(c.Phrase)) c.Phrase = "";

            switch (orderBy)
            {
                case InAuctionItemsOrderBy.BuyNowPrice: { oPredicate = (x => x.ConstPrice); break; }
                case InAuctionItemsOrderBy.Delivery: { oPredicate = (x => x.Delivery.Name); break; }
                case InAuctionItemsOrderBy.StartDate: { oPredicate = (x => x.Auction.StartDate); break; }
                case InAuctionItemsOrderBy.EndDate: { oPredicate = (x => x.Auction.EndDate); break; }
                default: { oPredicate = (x => x.Name); break; }
            }
            var items = _itemRepo.GetSortedItems(w =>w.UserId==userId && w.Status == Status.InAuction && w.Name.Contains(c.Phrase), oPredicate);

            List<Item> list = items.Skip((c.PageIndex - 1) * c.AmountOfPages).Take(c.AmountOfPages).ToList();

            var result = new PagedInAuctionItemsDTO
            {
                TotalAmount = items.Count(),
                Items = _mapper.Map<List<Item>, List<InAuctionItemDTO>>(list)
            };

            return result;
        }

        public PagedBoughtItemsDTO GetBoughtItems(BoughtItemsOrderBy orderBy, SearchCriteriaDTO searchDTO, string userId)
        {
            var c = searchDTO;
            Expression<Func<Item, object>> oPredicate;

            if (string.IsNullOrEmpty(c.Phrase)) c.Phrase = "";

            switch (orderBy)
            {
                case BoughtItemsOrderBy.Delivery: { oPredicate = (x => x.Delivery.Name); break; }
                case BoughtItemsOrderBy.StartDate: { oPredicate = (x => x.Auction.StartDate); break; }
                case BoughtItemsOrderBy.EndDate: { oPredicate = (x => x.Auction.EndDate); break; }
                case BoughtItemsOrderBy.BuyNowPrice: { oPredicate = (x => x.ConstPrice); break; }
                //case BoughtItemsOrderBy.BuyPrice: { oPredicate = (x => x.); break; }
                //case BoughtItemsOrderBy.TotalCost: { oPredicate = (x => x.); break; }
                default: { oPredicate = (x => x.Name); break; }
            }

            var items = _itemRepo.GetSortedItems(w =>w.UserId==userId && w.Status == Status.Bought && w.Name.Contains(c.Phrase), oPredicate);
            List<Item> list = items.Skip((c.PageIndex - 1) * c.AmountOfPages).Take(c.AmountOfPages).ToList();

            var result = new PagedBoughtItemsDTO
            {
                TotalAmount = items.Count(),
                Items = _mapper.Map<List<Item>, List<BoughtItemDTO>>(list)
            };

            return result;
        }

        public List<LatestItemDTO> GetLastAddedItems(Status status)
        {
            var spec = new FilterItemSpecyfication(status);
            var items = _itemRepo.GetLastAddedItems(spec, 4).ToList();
            var result = _mapper.Map<List<Item>, List<LatestItemDTO>>(items);

            return result;
        }

        public void Remove(int id)
        {
            var item = _itemRepo.GetById(id);
            _itemRepo.Remove(item);
            _unitOfWork.Save();
        }

        public void SetAuction(CreateAuctionDTO dto)
        {
            Item item = _itemRepo.GetById(dto.ItemId);
            Auction auction = _mapper.Map<CreateAuctionDTO, Auction>(dto);
            item.Status = Status.InAuction;
            item.Auction = auction;
            _unitOfWork.Save();
        }

        public AuctionDetailsDTO GetAuctionByItem(int id)
        {
            Item item = _itemRepo.GetById(id);
            AuctionDetailsDTO dto = _mapper.Map<Item, AuctionDetailsDTO>(item);
            return dto;
        }

        public void ChangeStatus(int id, Status newStatus)
        {
            Item item = _itemRepo.GetById(id);
            item.Status = newStatus;
            _unitOfWork.Save();
        }

        public void Create(NewItemDTO dto, string userId,string userName)
        {
            Item item = _mapper.Map<NewItemDTO, Item>(dto);
            item.Status = Status.Waiting;
            item.Delivery = _deliveryRepo.GetById(dto.MethId);
            item.Subcategory = _categoryRepo.GetSubcategory(dto.SubcatId);
            item.UserId = userId;
            item.UserName = userName;
            item.ItemDescriptions = _mapper.Map<List<DescriptionDTO>, List<ItemDescription>>(dto.Descriptions);

            _itemRepo.Add(item);
            _unitOfWork.Save();
        }
    }
}