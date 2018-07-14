using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class PagedInAuctionItemsDTO
    {
        public int TotalAmount { get; set; }
        public List<InAuctionItemDTO> Items { get; set; }
    }
}
