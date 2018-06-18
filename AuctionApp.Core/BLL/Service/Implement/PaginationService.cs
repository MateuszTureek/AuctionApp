using AuctionApp.Core.BLL.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Static
{
    public class PaginationService : IPaginationService
    {
        const int pageSize = 3;
        
        public static int PageNumber { get; set; }
        public static int PageSize { get { return pageSize; } private set { value = pageSize; } }
        public static int TotalCount { get; set; }

        public int CalcToSkip()
        {
            return (PageNumber - 1) * PageSize;
        }


        public int AmountOfPages()
        {
            double amountOfPages = 0;

            try
            {
                amountOfPages = Math.Ceiling(Convert.ToDouble(TotalCount / PageSize));
            }
            catch (DivideByZeroException)
            {
                // hanlde that
            }
            if (Convert.ToDouble(TotalCount % PageSize) != 0)
            {
                amountOfPages += 1;
            }
            return (int)amountOfPages;
        }
    }
}
