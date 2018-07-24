using AuctionApp.Core.BLL.DTO.Bid;
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
        PagedItemDTO GetItems(PagedItemCriteriaDTO dto);
        List<ItemDTO> GetLastAddedItems(Status status);
        ItemDetailsDTO GetItem(int id);
        List<SimpleItemDTO> SearchItems(string phrase);
        PagedWaitingItemsDTO GetWaitingItems(WaitingItemsOrderBy orderBy, SearchCriteriaDTO searchDTO);
        PagedInAuctionItemsDTO GetInAuctionItems(InAuctionItemsOrderBy orderBy, SearchCriteriaDTO searchDTO);
        PagedBoughtItemsDTO GetBoughtItems(BoughtItemsOrderBy orderBy, SearchCriteriaDTO searchDTO);
        void Create(NewItemDTO dto);
        void Remove(int id);
        void ChangeStatus(int id, Status newStatus);
        int AmountOfWaitingItems(string userId);
        int AmountOfAuctions(string userId);
        decimal CalcTotalCost(List<Item> items);
        decimal GetTotalLiabilities(string userId);
        void CreateItemAuction(CreateAuctionDTO dto);
        void CancelAuction(int id);
        ItemAuctionDTO GetAuctionDetails(int id);
        NewBidDTO GetBestBid(int itemid);
        void AddBidToItem(NewBidDTO dto, string userId);
        int GetLeadBidOfItem(string userId);
        List<CustomerBidDTO> GetCustomerBestBids(string userId);

        BidDetailsDTO GetBidDetails(int id);
    }
}