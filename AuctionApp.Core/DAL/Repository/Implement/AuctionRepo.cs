using AuctionApp.Core.DAL.Criteria;
using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Implement
{
    public class AuctionRepo : IAuctionRepo
    {
        readonly AuctionDbContext _dbContext;

        public AuctionRepo(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Item item)
        {
            _dbContext.Items.Add(item);
        }

        public void AddBid(Item item, decimal amount, string userId)
        {
            _dbContext.ClientBids.Add(new ClientBid()
            {
                UserId = userId,
                Bid = new Bid()
                {
                    BidAmount = amount,
                    DatePlaced = DateTime.Now,
                }
            });
        }

        public Item GetById(int id)
        {
            return _dbContext.Items
                .Include(i => i.Descriptions)
                .Include(i => i.Bids)
                .First(f => f.Id == id);
        }

        public string GetUserIdWhoMakeBid(int bidId)
        {
            return _dbContext.ClientBids.Where(s => s.BidId == bidId).Select(s => s.UserId).FirstOrDefault();
        }

        public int GetCount()
        {
            return _dbContext.Items.Count();
        }

        public IEnumerable<Item> GetCurrentAuctions(AuctionOfUserCriteria criteria)
        {
            var c = criteria;
            var skip = (c.PageNumber - 1) * c.PageSize;
            var userItems = _dbContext.ClientItems.Where(w => w.UserId == c.UserId);

            return userItems.Select(s => s.Item).OrderBy(o => o.AuctionEndDate)
                .Where(w => w.Subcategory.Id == c.SubcategoryId && w.Activated == true && w.AuctionEndDate > DateTime.Now)
                .Skip(skip).Take(c.PageSize).AsNoTracking();
        }

        public IEnumerable<Item> GetEndedAuctions(AuctionOfUserCriteria criteria)
        {
            var c = criteria;
            var skip = (c.PageNumber - 1) * c.PageSize;
            var userItems = _dbContext.ClientItems.Where(w => w.UserId == c.UserId);

            return userItems.Select(s => s.Item)
                .Where(w => w.Subcategory.Id == c.SubcategoryId && w.Activated == true && w.AuctionEndDate >= DateTime.Now)
                .Skip(skip).Take(c.PageSize).AsNoTracking();
        }

        public IEnumerable<Item> GetNoActivatedAuctions(AuctionOfUserCriteria criteria)
        {
            var c = criteria;
            var skip = (c.PageNumber - 1) * c.PageSize;
            var userItems = _dbContext.ClientItems.Where(w => w.UserId == c.UserId);

            return userItems.Select(s => s.Item)
                .Where(w => w.Subcategory.Id == c.SubcategoryId && w.Activated == false && w.AuctionEndDate > DateTime.Now)
                .Skip(skip).Take(c.PageSize).AsNoTracking();
        }

        public void Remove(Item item)
        {
            _dbContext.Items.Remove(item);
        }

        public IEnumerable<Item> TakeAuctions(int amount, bool activated)
        {
            return _dbContext.Items
                .Where(w => w.Activated == activated)
                .Include(i => i.Descriptions)
                .OrderByDescending(o => o.AuctionEndDate)
                .Take(amount)
                .AsNoTracking();
        }

        public int TakeAuctionsTotalCount<TKey>(Func<Item, TKey> predicateOrderBy,
                                      Func<Item, bool> predcateWhere)
        {
            var elementsByCondtions = _dbContext.Items
                .Include(i => i.Subcategory)
                .Include(i => i.Subcategory.Category)
                .Where(predcateWhere)
                .OrderBy(predicateOrderBy).AsQueryable();
            return elementsByCondtions.Count();
        }

        public IEnumerable<Item> TakeAuctions<TKey>(Func<Item, TKey> predicateOrderBy,
                                                    Func<Item, bool> predcateWhere,
                                                    int skip, int take)
        {
            return _dbContext.Items
                .Include(i=>i.Subcategory)
                .Include(i=>i.Subcategory.Category)
                .Where(predcateWhere)
                .OrderBy(predicateOrderBy)
                .Skip(skip)
                .Take(take)
                .AsEnumerable();
        }
    }
}