using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.Criteria
{
    public class AuctionCriteria
    {
        public int SubcategoryId { get; set; }
        public string UserId { get; set; }
        public short PageNumber { get; set; }
        public short PageSize { get; set; }
    }
}
