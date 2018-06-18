using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Criteria;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IAuctionService
    {
        List<LatestAuctionDTO> TakeAuctions(int amount, bool actived);
        List<AuctionDTO> GetAuctions(FilterAuctionDTO dto);
        int GetAmountOfPages(int pageSize);
    }
}
