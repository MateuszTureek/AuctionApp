using AuctionApp.Core.BLL.Criteria;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Implement
{
    /*
     * Expressions refactor
     */

    public class ItemService : IItemService
    {
        readonly IMapper _mapper;
        readonly IItemRepo _itemRepo;
        readonly UserManager<AppUser> _userManager;

        public ItemService(IMapper mapper,
                              IItemRepo itemRepo,
                              UserManager<AppUser> userManager)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
            _userManager = userManager;
        }


        public ItemDetailsDTO GetItem(int id)
        {
            string userId;
            AppUser user;

            var auction = _itemRepo.GetById(id);
            var singleAuctionDto = _mapper.Map<Item, ItemDetailsDTO>(auction);

            for (var i = 0; i < auction.Bids.Count; i += 1)
            {

                userId = _itemRepo.GetUserIdWhoMakeBid(auction.Bids[0].Id);
                user = _userManager.Users.First(f => f.Id == userId);
                if (user != null)
                {
                    singleAuctionDto.Bids[i].UserName = user.UserName;
                }

            }
            return singleAuctionDto;
        }

        public List<SimpleItemDTO> SearchItems(string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return new List<SimpleItemDTO>();
            return _mapper.Map<List<Item>, List<SimpleItemDTO>>(_itemRepo.SearchByPhrase(phrase).ToList());
        }

        public List<LatestItemDTO> GetItems(int amount, Status status)
        {
            var items = _itemRepo.GetItems(
                4,
                orderBy => orderBy.Name,
                w => w.Status == status).ToList();

            return _mapper.Map<List<Item>, List<LatestItemDTO>>(items);
        }

        public List<SimpleItemDTO> GetItems(ItemCriteria criteria, out int amountOfPages)
        {
            var c = criteria;
            List<Item> items = null;

            if (c.SubcategoryId != null)
                items = _itemRepo.GetItems(
                    c.GetSortBy(c.SortBy),
                    w => w.Subcategory.Id == c.SubcategoryId && w.Status == c.Status,
                    c.PageIndex, c.PageSize, out amountOfPages).ToList();
            else
            {
                if (c.CategoryId != null)
                    items = _itemRepo.GetItems(
                        c.GetSortBy(c.SortBy),
                        w => w.Subcategory.Category.Id == c.CategoryId && w.Status == c.Status,
                        c.PageIndex, c.PageSize, out amountOfPages).ToList();
                else items = _itemRepo.GetItems(
                    c.GetSortBy(c.SortBy),
                    w => w.Status == c.Status,
                    c.PageIndex, c.PageSize, out amountOfPages).ToList();
            }
            return _mapper.Map<List<Item>, List<SimpleItemDTO>>(items);
        }
    }
}