using AuctionApp.Core.BLL.Criteria;
using AuctionApp.Core.BLL.DTO.Auction;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IItemService
    {
        PagedItemDTO GetItems(ItemCriteria criteria);
        List<LatestItemDTO> GetLastAddedItems(Status status);
        ItemDetailsDTO GetItem(int id);
        List<SimpleItemDTO> SearchItems(string phrase);
        List<WaitingItemDTO> GetWaitingItems(WaitingItemsOrderBy orderBy, bool desc, string phrase, int amountOfPages);
        List<InAuctionItemDTO> GetInAuctionItems(InAuctionItemsOrderBy orderBy, bool desc, string phrase, int amountOfPages);
        List<BoughtItemDTO> GetBoughtItems(BoughtItemsOrderBy orderBy, bool desc, string phrase, int amountOfPages);

        AuctionDetailsDTO GetAuctionByItem(int id);
        void SetAuction(CreateAuctionDTO dto);
        void Remove(int id);
        void ChangeStatus(int id, Status newStatus);
    }
}