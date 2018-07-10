using AuctionApp.Core.DAL.Data.AuctionContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.UnitOfWork
{
    public class AuctionUnitOfWork : IUnitOfWork
    {
        readonly AuctionDbContext _db;

        public AuctionUnitOfWork(AuctionDbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
