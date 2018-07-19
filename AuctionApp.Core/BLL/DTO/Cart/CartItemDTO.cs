using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Cart
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImgSrc { get; set; }
        public decimal Price { get; set; }
        public string DeliveryName { get; set; }
        public decimal DeliveryCost { get; set; }
    }
}
