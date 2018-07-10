using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class PagedItemDTO
    {
        public int TotalPages { get; set; }

        public List<SimpleItemDTO> Items { get; set; }
    }
}
