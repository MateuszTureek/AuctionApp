using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class PagedItemCriteriaDTO
    {
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public int PageNumber { get; set; }
        public SortBy SortBy { get; set; }
        public Status Status { get; set; }
        public int PageSize { get; set; }
    }
}
