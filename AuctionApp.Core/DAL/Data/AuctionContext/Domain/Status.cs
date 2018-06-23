using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public enum Status
    {
        Waiting = 1, // wait to change status by owner
        InAuction,
        Bought
    }
}
