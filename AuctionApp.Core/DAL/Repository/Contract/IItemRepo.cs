using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Specyfication.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Contract
{
    public interface IItemRepo : IGenericRepo<Item>
    {
        int GetLeadBidsCount(string userId);
        decimal FinancialLiabilities(string userId);
        int WaitingItemsCount(string userId);
        int InAuctionItemsCount(string userId);
        IEnumerable<Item> Find(ISpec<Item, bool> spec);
        IEnumerable<Item> Find(ISpec<Item, bool> spec, ISpec<Item, object> orderSpec);
        IEnumerable<Item> GetLastAddedItems(ISpec<Item, bool> spec, int amount);
        IEnumerable<Item> GetSortedItems(Expression<Func<Item, bool>> conditionPredicate, Expression<Func<Item, object>> orderPredicate);
    }
}

