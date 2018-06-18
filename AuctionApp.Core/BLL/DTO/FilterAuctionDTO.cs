using AuctionApp.Core.BLL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class FilterAuctionDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public SortBy SortBy { get; set; }
    }
}
