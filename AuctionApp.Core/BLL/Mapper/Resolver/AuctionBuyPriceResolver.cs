using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class AuctionBuyPriceResolver<TDestination> : IValueResolver<Item, TDestination, decimal>
    {
        public decimal Resolve(Item source, TDestination destination, decimal destMember, ResolutionContext context)
        {
            int? bestBidId = source.Auction.BestBidId;
            if (bestBidId != null)
                return source.Auction.Bids.First(f => f.Id == bestBidId).BidAmount;
            return 0.00M;
        }
    }
}
