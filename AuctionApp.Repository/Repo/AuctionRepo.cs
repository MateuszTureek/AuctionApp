using AuctionApp.Core.AuctionContext;
using AuctionApp.Core.AuctionContext.Domain;
using AuctionApp.Repository.Criteria;
using AuctionApp.Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.Repo
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

        public Item Get(int id)
        {
            return _dbContext.Items.Find(id);
        }

        public IEnumerable<Item> GetCurrentAuctions(AuctionCriteria criteria)
        {
            var c = criteria;
            var skip = (c.PageNumber - 1) * c.PageSize;
            var userItems = _dbContext.ClientItems.Where(w => w.UserId == c.UserId);

            return userItems.Select(s => s.Item).OrderBy(o => o.AuctionEndDate)
                .Where(w => w.Subcategory.Id == c.SubcategoryId && w.Activated == true && w.AuctionEndDate > DateTime.Now)
                .Skip(skip).Take(c.PageSize);
        }

        public IEnumerable<Item> GetEndedAuctions(AuctionCriteria criteria)
        {
            var c = criteria;
            var skip = (c.PageNumber - 1) * c.PageSize;
            var userItems = _dbContext.ClientItems.Where(w => w.UserId == c.UserId);

            return userItems.Select(s => s.Item)
                .Where(w => w.Subcategory.Id == c.SubcategoryId && w.Activated == true && w.AuctionEndDate >= DateTime.Now)
                .Skip(skip).Take(c.PageSize);
        }

        public IEnumerable<Item> GetNoActivatedAuctions(AuctionCriteria criteria)
        {
            var c = criteria;
            var skip = (c.PageNumber - 1) * c.PageSize;
            var userItems = _dbContext.ClientItems.Where(w => w.UserId == c.UserId);

            return userItems.Select(s => s.Item)
                .Where(w => w.Subcategory.Id == c.SubcategoryId && w.Activated == false && w.AuctionEndDate > DateTime.Now)
                .Skip(skip).Take(c.PageSize);
        }

        public void Remove(Item item)
        {
            _dbContext.Items.Remove(item);
        }
    }
}