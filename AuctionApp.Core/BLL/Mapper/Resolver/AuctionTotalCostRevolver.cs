using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class AuctionTotalCostRevolver<TDestination> : IValueResolver<Item, TDestination, decimal>
    {
        public decimal Resolve(Item source, TDestination destination, decimal destMember, ResolutionContext context)
        {
            if (source.Auction != null)
            {
                int? bestBidId = source.Auction.BestBidId;
                if (bestBidId != null)
                {
                    Bid bestBid = source.Auction.Bids.OrderByDescending(o => o.DatePlaced).First(f => f.Id == bestBidId);
                    decimal totalCost = bestBid.BidAmount + source.Delivery.Price;
                    return totalCost;
                }
            }
            return 0.00M;
        }
    }
}
