using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Criteria
{
    public class AuctionOfUserCriteria
    {
        public int SubcategoryId { get; set; }
        public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
