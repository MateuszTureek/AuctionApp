using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class InAuctionItem : ItemDTO
    {
        public DateTime AuctionEndDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
