using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class PagedBoughtItemsDTO
    {
        public int TotalAmount { get; set; }
        public List<BoughtItemDTO> Items { get; set; }
    }
}
