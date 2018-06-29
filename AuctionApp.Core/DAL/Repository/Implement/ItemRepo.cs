using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
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
    public class ItemRepo : IItemRepo
    {
        readonly AuctionDbContext _dbContext;

        public ItemRepo(AuctionDbContext dbContext)
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
                .Include(i => i.Payment)
                .First(f => f.Id == id);
        }

        public IEnumerable<Item> GetItems<TKey>(
            Expression<Func<Item, TKey>> orderPredicate,
            Expression<Func<Item, bool>> wherePredicate,
            int pageIndex,
            int pageSize,
            out int totalPages)
        {
            var itemsQueryable = _dbContext.Items
                .Include(i => i.Payment)
                .Where(wherePredicate)
                .OrderBy(orderPredicate);

            totalPages = itemsQueryable.Count();

            return itemsQueryable
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        public string GetUserIdWhoMakeBid(int bidId)
        {
            return _dbContext.ClientBids
                .Where(s => s.BidId == bidId)
                .Select(s => s.UserId)
                .FirstOrDefault();
        }


        public void Remove(Item item)
        {
            _dbContext.Items.Remove(item);
        }

        public IEnumerable<Item> SearchByPhrase(string phrase)
        {
            return _dbContext.Items
                .Where(w => w.Name.ToLower(CultureInfo.CurrentCulture).Contains(phrase.ToLower(CultureInfo.CurrentCulture)))
                .Take(20)
                .AsNoTracking()
                .AsEnumerable();
        }

        public IEnumerable<Item> GetItems<TKey>(
            int amount,
            Expression<Func<Item, TKey>> orderPredicate,
            Expression<Func<Item, bool>> wherePredicate)
        {
            return _dbContext.Items
                .Where(wherePredicate)
                .OrderBy(orderPredicate)
                .Take(amount)
                .AsNoTracking()
                .AsEnumerable();
        }
    }
}