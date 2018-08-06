using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Core.DAL.Repository.Implement {
    public class BidRepo : GenericRepo<Bid>, IBidRepo {
        public BidRepo (AuctionDbContext db) : base (db) { }

        public override async Task<Bid> GetById (int id) {
            return await _dbSet
                .Include (i => i.Item)
                .Include (i => i.Item.Subcategory)
                .Include (i => i.Item.Payment).FirstOrDefaultAsync (f => f.Id == id);
        }
    }
}