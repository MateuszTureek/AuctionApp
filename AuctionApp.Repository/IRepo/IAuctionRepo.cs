using AuctionApp.Data.AuctionContext.Domain;
using AuctionApp.Repository.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.IRepo
{
    public interface IAuctionRepo
    {
        IEnumerable<Item> GetNoActivatedAuctions(AuctionCriteria criteria);
        IEnumerable<Item> GetCurrentAuctions(AuctionCriteria criteria);
        IEnumerable<Item> GetEndedAuctions(AuctionCriteria criteria);
        Item Get(int id);
        void Add(Item item);
        void Remove(Item item);
        void AddBid(Item item, decimal amount, string userId);
    }
}
