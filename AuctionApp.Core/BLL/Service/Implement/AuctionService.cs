using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class AuctionService : IAuctionService
    {
        readonly IItemRepo _itemRepo;

        public AuctionService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public decimal FinancialLiabilities(string userId)
        {
            return _itemRepo.FinancialLiabilities(userId);
        }

        public int GetLeadBidsCount(string userId)
        {
            return _itemRepo.GetLeadBidsCount(userId);
        }
    }
}
