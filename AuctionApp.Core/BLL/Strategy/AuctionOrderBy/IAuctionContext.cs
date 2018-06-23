using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Strategy.AuctionOrderBy
{
    public interface IAuctionContext
    {
        List<Item> GetAuctions(FilterItemDTO dto);
    }
}
