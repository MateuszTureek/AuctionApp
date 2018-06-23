using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Strategy.AuctionOrderBy
{
    public class AuctionContext : IAuctionContext
    {
        IStrategy _strategy;

        public AuctionContext(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public List<Item> GetAuctions(FilterItemDTO dto)
        {
            return _strategy.GetAuctionsOrderBy(dto);
        }
    }
}
