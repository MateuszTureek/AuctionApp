using AuctionApp.Core.BLL.Criteria;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IItemService
    {
        List<SimpleItemDTO> GetItems(ItemCriteria criteria, out int amountOfPages);
        List<LatestItemDTO> GetItems(int amount, Status status);
        ItemDetailsDTO GetItem(int id);
        List<SimpleItemDTO> SearchItems(string phrase);
    }
}
