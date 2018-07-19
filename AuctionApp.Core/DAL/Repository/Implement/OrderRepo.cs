using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Repository.Implement
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        public OrderRepo(AuctionDbContext db) : base(db)
        {
        }
    }
}
