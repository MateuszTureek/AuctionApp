using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Repository.Contract
{
    public interface ICustomerRepo
    {
        IEnumerable<Bid> GetBids();
        AppUser GetById(string id);
    }
}
