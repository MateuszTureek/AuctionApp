using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.BLL.DTO.Item;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;

namespace AuctionApp.Core.BLL.Service.Contract {
    public interface IItemService {
        PagedItemDTO GetItems (PagedItemCriteriaDTO dto);
        List<ItemDTO> GetLastAddedItems (Status status);
        Task<ItemDetailsDTO> GetItemAsync (int id);
        List<SimpleItemDTO> SearchItems (string phrase);
        PagedWaitingItemsDTO GetWaitingItems (WaitingItemsOrderBy orderBy, SearchCriteriaDTO searchDTO);
        PagedInAuctionItemsDTO GetInAuctionItems (InAuctionItemsOrderBy orderBy, SearchCriteriaDTO searchDTO);
        PagedBoughtItemsDTO GetBoughtItems (BoughtItemsOrderBy orderBy, SearchCriteriaDTO searchDTO);
        Task CreateAsync (NewItemDTO dto);
        Task RemoveAsync (int id);
        Task ChangeStatusAsync (int id, Status newStatus);
        int AmountOfWaitingItems (string userId);
        int AmountOfAuctions (string userId);
        decimal CalcTotalCost (List<Item> items);
        decimal GetTotalLiabilities (string userId);
        Task CreateItemAuctionAsync (CreateAuctionDTO dto);
        Task CancelAuctionAsync (int id);
        Task<ItemAuctionDTO> GetAuctionDetailsAsync (int id);
        Task<NewBidDTO> GetBestBidAsync (int itemid);
        Task AddBidToItemAsync (NewBidDTO dto, string userId);
        int GetLeadBidOfItem (string userId);
        Task<BidDetailsDTO> GetBidDetailsAsync (int id);
        List<CustomerBidDTO> GetCustomerBestBids (string userId);
        Task<List<CustomerShortBidDTO>> GetShortCustomerBestBidsAsync (string userId);
        List<ShortBidOfAuctionDTO> GetShortMyAuctions (string userId);
    }
}