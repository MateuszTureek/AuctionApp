using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.BLL.Criteria
{
    public class ItemCriteria
    {
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public SortBy SortBy { get; set; }
        public Status Status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
