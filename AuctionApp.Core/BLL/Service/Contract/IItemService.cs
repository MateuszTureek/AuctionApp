using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.DAL.Criteria;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IItemService
    {
        List<LatestItemDTO> TakeItems(int amount, bool actived);
        List<ItemDTO> GetItems(FilterItemDTO dto);
        int GetAmountOfPages(int pageSize);
        SingleItemDTO GetItem(int id);

    }
}
