using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Implement
{
    public class BidRepo : GenericRepo<Bid>, IBidRepo
    {
        public BidRepo(AuctionDbContext db) : base(db)
        {
        }

        public override Bid GetById(int id)
        {
            return _dbSet
                    .Include(i=>i.Item)
                    .Include(i=>i.Item.Subcategory)
                    .Include(i=>i.Item.Payment).First(f=>f.Id==id);
        }
    }
}