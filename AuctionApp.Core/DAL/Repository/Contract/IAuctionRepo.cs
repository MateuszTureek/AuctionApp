using AuctionApp.Core.DAL.Criteria;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Contract
{
    public interface IAuctionRepo
    {
        IEnumerable<Item> GetNoActivatedAuctions(AuctionOfUserCriteria criteria);
        IEnumerable<Item> GetCurrentAuctions(AuctionOfUserCriteria criteria);
        IEnumerable<Item> GetEndedAuctions(AuctionOfUserCriteria criteria);

        IEnumerable<Item> TakeAuctions(int amount, bool activated);
        IEnumerable<Item> TakeAuctions<TKey>(Func<Item, TKey> predicateOrderBy,
                                             Func<Item, bool> predcateWhere,
                                             int skip, int take);
        int TakeAuctionsTotalCount<TKey>(Func<Item, TKey> predicateOrderBy,
                                         Func<Item, bool> predcateWhere);
        int GetCount();
        Item GetById(int id);
        void Add(Item item);
        void Remove(Item item);
        void AddBid(Item item, decimal amount, string userId);
        string GetUserIdWhoMakeBid(int bidId);
        IEnumerable<Item> SearchByPhrase(string phrase);
    }
}
