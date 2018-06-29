using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class WaitingItemDTO : ItemDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime AuctionEndDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
