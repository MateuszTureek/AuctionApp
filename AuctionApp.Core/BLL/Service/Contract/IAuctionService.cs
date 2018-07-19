using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IAuctionService
    {
        decimal FinancialLiabilities(string userId);
        int GetLeadBidsCount(string userId);
    }
}
