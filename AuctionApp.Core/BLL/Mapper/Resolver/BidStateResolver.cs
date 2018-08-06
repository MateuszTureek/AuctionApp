using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AutoMapper;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class BidStateResolver<TDestination> : IValueResolver<Bid, TDestination, BidState>
    {
        readonly IItemService _itemService;

        public BidStateResolver(IItemService itemService)
        {
            _itemService = itemService;
        }

        public BidState Resolve(Bid source, TDestination destination, BidState destMember, ResolutionContext context)
        {
            var bestBid = _itemService.GetBestBidAsync(source.Item.Id).Result;

            if (source.BidAmount == bestBid.BestBidPrice) return BidState.Najlepsza;
            return BidState.Przebita;
        }
    }
}
