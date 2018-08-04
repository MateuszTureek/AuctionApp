using System;
using System.Collections.Generic;
using System.Text;
using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;

namespace AuctionApp.Core.DAL.Repository.Implement {
    public class PaymentRepo : GenericRepo<Payment>, IPaymentRepo {
        public PaymentRepo (AuctionDbContext db) : base (db) { }
    }
}