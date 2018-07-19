﻿using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Specyfication.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                .Include(i => i.Auction)
                .Include(i => i.Auction.Bids)
                .Include(i => i.Subcategory)
                .Include(i => i.Subcategory.Category)
                .Include(i => i.Delivery)
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
                .Include(i => i.Delivery)
                .Where(spec.ToExpression())
                .OrderBy(orderSpec.ToExpression())
                .AsNoTracking();

            return result;
        }

        public override Item GetById(int id)
        {
            return _dbSet
                .Include(i => i.Auction)
                .Include(i => i.Auction.Bids)
                .Include(i => i.ItemDescriptions)
                .Include(i => i.Delivery)
                .First(f => f.Id == id);
        }

        public IEnumerable<Item> GetLastAddedItems(ISpec<Item, bool> spec, int amount)
        {
            var result = _dbSet
                .Include(i => i.Subcategory)
                .Include(i => i.Subcategory.Category)
                .Include(i => i.Delivery)
                .Where(spec.ToExpression())
                .OrderBy(x => x.Name)
                .Take(amount)
                .AsNoTracking();

            return result;
        }

        public int GetLeadBidsCount(string userId)
        {
            return _dbSet.Select(s => s.Auction.Bids.Where(w => w.UserId == userId)).Count();
        }

        public IEnumerable<Item> GetSortedItems(
            Expression<Func<Item, bool>> conditionPredicate,
            Expression<Func<Item, object>> orderPredicate)
        {
            var result = _dbSet
                .Include(i => i.Auction)
                .Include(i => i.Auction.Bids)
                .Include(i => i.Subcategory.Category)
                .Include(i => i.Delivery)
                .Where(conditionPredicate)
                .OrderBy(orderPredicate)
                .AsNoTracking()
                .AsEnumerable();
            return result;
        }

        public decimal FinancialLiabilities(string userId)
        {
            var userBids = _dbSet.Where(w => w.Status == Status.Bought).Include(i=>i.Auction.Bids).SelectMany(s => s.Auction.Bids.Where(w => w.UserId == userId));
            var wonBids = userBids.Where(w => w.Auction.BestBidId == w.Id);

            return wonBids.Sum(s => s.BidAmount + s.Auction.Item.Delivery.Price);
        }

        public int InAuctionItemsCount(string userId)
        {
            return _dbSet.Where(w => w.Status == Status.InAuction && w.UserId == userId).Count();
        }

        public int WaitingItemsCount(string userId)
        {
            return _dbSet.Where(w => w.Status == Status.Waiting && w.UserId == userId).Count();
        }
    }
}