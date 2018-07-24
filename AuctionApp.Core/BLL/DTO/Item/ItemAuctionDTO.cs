using AuctionApp.Core.BLL.DTO.Bid;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class ItemAuctionDTO
    {
        public string ItemName { get; set; }
        public string ImgSrc { get; set; }
        public decimal PriceBuyNow { get; set; }
        public string Payment { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }

        public List<ItemBidDTO> Bids { get; set; }
    }
}
