using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Specyfication.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Implement
{
    public class ItemRepo : GenericRepo<Item>, IItemRepo
    {
        public ItemRepo(AuctionDbContext db) : base(db)
        {
        }
        public IEnumerable<Item> Find(ISpec<Item, bool> spec)
        {
            var result = _dbSet
                .Include(i => i.Subcategory)
                .Include(i => i.Subcategory.Category)
                .Where(spec.ToExpression())
                .OrderBy(x => x.Name)
                .AsNoTracking();

            return result;
        }

        public IEnumerable<Item> Find(ISpec<Item, bool> spec, ISpec<Item, object> orderSpec)
        {
            var result = _dbSet
                .Include(i => i.Subcategory)
                .Include(i => i.Subcategory.Category)
                .Include(i => i.Payment)
                .Where(spec.ToExpression())
                .OrderBy(orderSpec.ToExpression())
                .AsNoTracking()
                .AsEnumerable();

            return result;
        }

        public IEnumerable<Bid> GetBids(string userId)
        {
            var result = _dbSet
                .SelectMany(s => s.Bids)
                .Include(i => i.Item)
                .Include(i => i.Item.Payment)
                .Where(w => w.UserId == userId)
                .AsNoTracking().AsEnumerable();
            return result;
        }

        public IEnumerable<Bid> GetBidsForCustomerItems(string userId)
        {
            var result = _dbSet
                .Where(w => w.UserId == userId)
                .SelectMany(s => s.Bids)
                .Include(i => i.Item)
                .OrderByDescending(o=>o.DatePlaced)
                .AsNoTracking()
                .AsEnumerable();
            return result;
        }

        public override Item GetById(int id)
        {
            return _dbSet
                .Include(i => i.ItemDescriptions)
                .Include(i => i.Payment)
                .Include(i => i.Bids)
                .First(f => f.Id == id);
        }

        public IEnumerable<Bid> GetCustomerBestBids(string userId)
        {
            var result = _dbSet
                .Select(s => s.Bids)
                .Select(s => s.Where(w => w.UserId == userId))
                .Select(s => s.Where(w => w.BidAmount == s.Max(m => m.BidAmount)))
                .Where(w => w.Count() > 0)
                .SelectMany(s => s)
                .Include(i => i.Item)
                .AsNoTracking().AsEnumerable();
            return result;
        }

        public IEnumerable<Item> GetLatestAddedItems(ISpec<Item, bool> spec, int amount)
        {
            var result = _dbSet
                .Include(i => i.Subcategory)
                .Include(i => i.Subcategory.Category)
                .Include(i => i.Payment)
                .Where(spec.ToExpression())
                .OrderBy(x => x.Name)
                .Take(amount)
                .AsNoTracking();

            return result;
        }

        public IEnumerable<Item> GetSortedItems(
            ISpec<Item, bool> spec,
            ISpec<Item, object> orderSpec)
        {
            var result = _dbSet
                .Include(i=>i.Payment)
                .Include(i=>i.Order)
                .Include(i => i.Subcategory.Category)
                .Where(spec.ToExpression())
                .OrderBy(orderSpec.ToExpression())
                .AsNoTracking()
                .AsEnumerable();
            return result;
        }

        public int InAuctionItemsAmount(string userId)
        {
            return _dbSet.Where(w => w.Status == Status.InAuction && w.UserId == userId).Count();
        }

        public int LeadingBidsAmount(string userId)
        {
            var result = _dbSet
                .Select(s => s.Bids)
                .Select(s => s.Where(w => w.BidAmount == s.Max(m => m.BidAmount) && w.UserId == userId))
                .Where(w => w.Count() > 0);

            return result.Count();
        }

        public int WaitingItemsAmount(string userId)
        {
            return _dbSet.Where(w => w.Status == Status.Waiting && w.UserId == userId).Count();
        }
    }
}