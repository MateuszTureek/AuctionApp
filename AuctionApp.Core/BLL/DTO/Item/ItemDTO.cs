using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public abstract class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgSrc { get; set; }
        public decimal BuyNowPrice { get; set; }
    }
}
