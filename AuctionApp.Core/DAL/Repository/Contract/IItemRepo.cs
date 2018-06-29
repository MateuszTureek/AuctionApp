using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Contract
{
    public interface IItemRepo
    {
        Item GetById(int id);
        void Add(Item item);
        void Remove(Item item);
        void AddBid(Item item, decimal amount, string userId);
        string GetUserIdWhoMakeBid(int bidId);

        IEnumerable<Item> SearchByPhrase(string phrase);

        IEnumerable<Item> GetItems<TKey>(
            Expression<Func<Item, TKey>> orderPredicate,
            Expression<Func<Item, bool>> wherePredicate,
            int pageIndex, int pageSize,
            out int totalPages);

        IEnumerable<Item> GetItems<TKey>(
            int amount,
            Expression<Func<Item, TKey>> orderPredicate,
            Expression<Func<Item, bool>> wherePredicate);
    }
}
