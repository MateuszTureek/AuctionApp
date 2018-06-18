using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IPaginationService
    {
        int CalcToSkip();
        int AmountOfPages();
    }
}
