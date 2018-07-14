using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class PagedWaitingItemsDTO
    {
        public int TotalAmount { get; set; }
        public List<WaitingItemDTO> Items { get; set; }
    }
}
