using AuctionApp.Core.DAL.Criteria;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Contract
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
