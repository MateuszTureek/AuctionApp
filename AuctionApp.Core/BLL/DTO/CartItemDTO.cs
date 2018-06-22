using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class CartItemDTO
    {
        public string ItemName { get; set; }
        public string ImgSrc { get; set; }
        public decimal Price { get; set; }
    }
}
