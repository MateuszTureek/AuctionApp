using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class AuctionBuyerNameResolver<TDestination> : IValueResolver<Item, TDestination, string>
    {
        public string Resolve(Item source, TDestination destination, string destMember, ResolutionContext context)
        {
            int? bestBidId = source.Auction.BestBidId;
            if (bestBidId != null)
                return source.Auction.Bids.First(f => f.Id == bestBidId).Username;
            return "";
        }
    }
}
