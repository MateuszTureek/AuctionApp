using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AutoMapper;
using System;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class AuctionEndDateResolver<TDestination> : IValueResolver<Item, TDestination, double>
    {
        public double Resolve(Item source, TDestination destination, double destMember, ResolutionContext context)
        {
            if (source.AuctionEnd != null)
                return source.AuctionEnd.Value.ToUniversalTime()
                    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                    .TotalMilliseconds;
            return 0.00;
        }
    }
}