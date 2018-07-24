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
        int WaitingItemsAmount(string userId);
        int InAuctionItemsAmount(string userId);
        int LeadingBidsAmount(string userId);
        IEnumerable<Item> Find(ISpec<Item, bool> spec);
        IEnumerable<Item> Find(ISpec<Item, bool> spec, ISpec<Item, object> orderSpec);
        IEnumerable<Item> GetLatestAddedItems(ISpec<Item, bool> spec, int amount);
        IEnumerable<Item> GetSortedItems(ISpec<Item, bool> spec, ISpec<Item, object> orderSpec);
        IEnumerable<Bid> GetBids(string userId);
        IEnumerable<Bid> GetCustomerBestBids(string userId);

    }
}

