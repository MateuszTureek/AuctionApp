using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.DAL.Repository.Implement
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        public OrderRepo(AuctionDbContext db) : base(db)
        {
        }

        public decimal FinancialLiabilities(string userId)
        {
            var result = _dbSet.Where(w => w.BuyerId == userId).Sum(s => s.TotalCost);
            return result;
        }
    }
}