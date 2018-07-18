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

        PagedWaitingItemsDTO GetWaitingItems(WaitingItemsOrderBy orderBy, SearchCriteriaDTO searchDTO, string userId);
        PagedInAuctionItemsDTO GetInAuctionItems(InAuctionItemsOrderBy orderBy, SearchCriteriaDTO searchDTO, string userId);
        PagedBoughtItemsDTO GetBoughtItems(BoughtItemsOrderBy orderBy, SearchCriteriaDTO searchDTO, string userId);

        AuctionDetailsDTO GetAuctionByItem(int id);

        void Create(NewItemDTO dto,string userId, string userName);
        void SetAuction(CreateAuctionDTO dto);
        void Remove(int id);
        void ChangeStatus(int id, Status newStatus);
    }
}