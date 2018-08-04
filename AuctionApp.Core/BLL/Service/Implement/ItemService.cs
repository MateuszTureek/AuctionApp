using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Specyfication;
using AuctionApp.Core.DAL.UnitOfWork.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Core.BLL.Service.Implement {
    public class ItemService : IItemService {
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;
        readonly IUnitOfWork _unitOfWork;
        readonly IPhotoService _photoService;
        public ItemService (
            IMapper mapper,
            UserManager<AppUser> userManager,
            IUnitOfWork unitOfWork,
            IPhotoService photoService) {
            _mapper = mapper;
            _userManager = userManager;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
        }

        public ItemDetailsDTO GetItem (int id) {
            var item = _unitOfWork.ItemRepo.GetById (id);
            var result = _mapper.Map<Item, ItemDetailsDTO> (item);

            return result;
        }

        public List<SimpleItemDTO> SearchItems (string phrase) {
            if (string.IsNullOrEmpty (phrase)) return new List<SimpleItemDTO> ();

            CultureInfo culture = new CultureInfo ("pl-PL");
            var items = _unitOfWork.ItemRepo.Find (x => x.Name.ToLower (culture).Contains (phrase.ToLower (culture))).ToList ();

            return _mapper.Map<List<Item>, List<SimpleItemDTO>> (items);
        }

        public PagedItemDTO GetItems (PagedItemCriteriaDTO dto) {
            var c = dto;
            var predicateSpec = new FilterItemSpecyfication (c.Status, c.CategoryId, c.SubcategoryId);
            var orderSpec = new OrderItemSpecyfication (c.SortBy);
            var items = _unitOfWork.ItemRepo.Find (predicateSpec, orderSpec);
            var result = new PagedItemDTO ();

            result.TotalPages = (int) Math.Ceiling ((decimal) items.Count () / c.PageSize);
            items = items.Skip ((c.PageNumber - 1) * c.PageSize).Take (c.PageSize).ToList ();
            result.Items = _mapper.Map<List<Item>, List<SimpleItemDTO>> (items.ToList ());

            return result;
        }

        public PagedWaitingItemsDTO GetWaitingItems (WaitingItemsOrderBy orderBy, SearchCriteriaDTO searchDTO) {
            var c = searchDTO;
            var orderSpec = new OrderWaitingItemSpecyfication (orderBy);
            var predicateSpec = new ItemSpecyfication (Status.Waiting, searchDTO.UserId, searchDTO.Phrase);
            var items = _unitOfWork.ItemRepo.GetSortedItems (predicateSpec, orderSpec);
            List<Item> list = items.Skip ((c.PageIndex - 1) * c.AmountOfPages).Take (c.AmountOfPages).ToList ();
            var result = new PagedWaitingItemsDTO () {
                TotalAmount = items.Count (),
                Items = _mapper.Map<List<Item>, List<WaitingItemDTO>> (list)
            };

            return result;
        }

        public PagedInAuctionItemsDTO GetInAuctionItems (InAuctionItemsOrderBy orderBy, SearchCriteriaDTO searchDTO) {
            var c = searchDTO;
            var spec = new ItemSpecyfication (Status.InAuction, searchDTO.UserId, searchDTO.Phrase);
            var orderSpec = new OrderInAuctionItemSpecyfication (orderBy);
            var items = _unitOfWork.ItemRepo.GetSortedItems (spec, orderSpec);
            List<Item> list = items.Skip ((c.PageIndex - 1) * c.AmountOfPages).Take (c.AmountOfPages).ToList ();
            var result = new PagedInAuctionItemsDTO {
                TotalAmount = items.Count (),
                Items = _mapper.Map<List<Item>, List<InAuctionItemDTO>> (list)
            };

            return result;
        }

        public PagedBoughtItemsDTO GetBoughtItems (BoughtItemsOrderBy orderBy, SearchCriteriaDTO searchDTO) {
            var c = searchDTO;
            var spec = new ItemSpecyfication (Status.Bought, searchDTO.UserId, searchDTO.Phrase);
            var orderSpec = new OrderBoughtItemSpecyfication (orderBy);

            var items = _unitOfWork.ItemRepo.GetSortedItems (spec, orderSpec);
            List<Item> list = items.Skip ((c.PageIndex - 1) * c.AmountOfPages).Take (c.AmountOfPages).ToList ();

            var result = new PagedBoughtItemsDTO {
                TotalAmount = items.Count (),
                Items = _mapper.Map<List<Item>, List<BoughtItemDTO>> (list)
            };

            return result;
        }

        public List<ItemDTO> GetLastAddedItems (Status status) {
            var spec = new FilterItemSpecyfication (status);
            var items = _unitOfWork.ItemRepo.GetLatestAddedItems (spec, 4).ToList ();
            var result = _mapper.Map<List<Item>, List<ItemDTO>> (items);

            return result;
        }

        public void Remove (int id) {
            var item = _unitOfWork.ItemRepo.GetById (id);
            _photoService.DeletePhoto (item.ImgSrc);
            _unitOfWork.ItemRepo.Remove (item);
            _unitOfWork.Save ();
        }

        public void ChangeStatus (int id, Status newStatus) {
            Item item = _unitOfWork.ItemRepo.GetById (id);
            item.Status = newStatus;
            _unitOfWork.Save ();
        }

        public void Create (NewItemDTO dto) {
            Item item = _mapper.Map<NewItemDTO, Item> (dto);
            _photoService.AddPhoto (dto.File);

            item.Status = Status.Waiting;
            item.Payment = _unitOfWork.PaymentRepo.GetById (dto.PaymentId);
            item.Subcategory = _unitOfWork.CategoryRepo.GetSubcategory (dto.SubcatId);
            item.UserId = dto.UserId;
            item.ImgSrc = _photoService.GetLocalFilePath ();
            item.Username = dto.Username;
            item.AuctionStart = null;
            item.AuctionEnd = null;
            item.Order = null;
            item.AddDescriptions (_mapper.Map<List<DescriptionDTO>, List<ItemDescription>> (dto.Descriptions));

            _unitOfWork.ItemRepo.Add (item);
            _unitOfWork.Save ();
        }

        public int AmountOfWaitingItems (string userId) {
            return _unitOfWork.ItemRepo.WaitingItemsAmount (userId);
        }

        public int AmountOfAuctions (string userId) {
            return _unitOfWork.ItemRepo.InAuctionItemsAmount (userId);
        }

        public decimal CalcTotalCost (List<Item> items) {
            //return items.Sum(s => s.ConstPrice + s.Payment.Price);
            throw new NotImplementedException ();
        }

        public decimal GetTotalLiabilities (string userId) {
            return _unitOfWork.OrderRepo.FinancialLiabilities (userId);
        }

        public void CreateItemAuction (CreateAuctionDTO dto) {
            var item = _unitOfWork.ItemRepo.GetById (dto.ItemId);
            item.Status = Status.InAuction;
            item.AuctionStart = dto.AuctionStart;
            item.AuctionEnd = dto.AuctionEnd;
            _unitOfWork.Save ();
        }

        public void CancelAuction (int id) {
            var item = _unitOfWork.ItemRepo.GetById (id);

            item.AuctionStart = null;
            item.AuctionEnd = null;
            item.Status = Status.Waiting;
            item.ClearBids ();

            _unitOfWork.Save ();
        }

        public ItemAuctionDTO GetAuctionDetails (int id) {
            var item = _unitOfWork.ItemRepo.GetById (id);
            var result = _mapper.Map<Item, ItemAuctionDTO> (item);
            return result;
        }

        public NewBidDTO GetBestBid (int itemid) {
            var item = _unitOfWork.ItemRepo.GetById (itemid);
            List<Bid> bids = item.Bids;
            if (bids.Count > 0) {
                var maxBidAmount = bids.Max (m => m.BidAmount);
                var bestBid = bids.OrderBy (o => o.DatePlaced).First (f => f.BidAmount == maxBidAmount);
                NewBidDTO dto = _mapper.Map<Bid, NewBidDTO> (bestBid);
                return dto;
            }
            return new NewBidDTO {
                BestBidPrice = 0.00M,
                    ItemId = itemid,
                    ItemName = item.Name,
                    MyBid = 0.00M
            };
        }

        public void AddBidToItem (NewBidDTO dto, string userId) {
            Item item = _unitOfWork.ItemRepo.GetById (dto.ItemId);

            if (item.UserId == userId) throw new Exception ("You cannot add offer to own item.");

            var bestBid = GetBestBid (item.Id);

            if (bestBid.Username == dto.Username) throw new Exception ("You cannot outbid yourself");

            item.AddBid (new Bid {
                BidAmount = dto.MyBid,
                    DatePlaced = DateTime.Now,
                    UserId = userId,
                    Username = dto.Username
            });
            _unitOfWork.Save ();
        }

        public int GetLeadBidOfItem (string userId) {
            var result = _unitOfWork.ItemRepo.LeadingBidsAmount (userId);
            return result;
        }

        public List<CustomerBidDTO> GetCustomerBestBids (string userId) {
            var bids = _unitOfWork.ItemRepo.GetCustomerBestBids (userId).ToList ();
            var dto = _mapper.Map<List<Bid>, List<CustomerBidDTO>> (bids);
            return dto;
        }

        public BidDetailsDTO GetBidDetails (int id) {
            Bid bid = _unitOfWork.BidRepo.GetById (id);
            BidDetailsDTO dto = _mapper.Map<Bid, BidDetailsDTO> (bid);
            return dto;
        }

        public List<CustomerShortBidDTO> GetShortCustomerBestBids (string userId) {
            var bids = _unitOfWork.ItemRepo.GetCustomerBestBids (userId).ToList ();
            var dto = _mapper.Map<List<Bid>, List<CustomerShortBidDTO>> (bids);

            int length = bids.Count;
            Item item;
            for (var i = 0; i < length; i += 1) {
                item = _unitOfWork.ItemRepo.GetById (bids[i].Item.Id);
                dto[i].CurrentOffer = item.Bids.Max (m => m.BidAmount);
            }

            return dto;
        }

        public List<ShortBidOfAuctionDTO> GetShortMyAuctions (string userId) {
            var bids = _unitOfWork.ItemRepo.GetBidsForCustomerItems (userId).ToList ();
            var dto = _mapper.Map<List<Bid>, List<ShortBidOfAuctionDTO>> (bids);
            return dto;
        }
    }
}