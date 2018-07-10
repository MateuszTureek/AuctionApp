using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class AuctionEndDateResolver<TDestination> : IValueResolver<Item, TDestination, double>
    {
        public double Resolve(Item source, TDestination destination, double destMember, ResolutionContext context)
        {
            if (source.Auction.EndDate != null)
                return source.Auction.EndDate.Value.ToUniversalTime()
                    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                    .TotalMilliseconds;
            return 0.00;
        }
    }
}
