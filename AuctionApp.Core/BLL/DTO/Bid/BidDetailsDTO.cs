using System;

namespace AuctionApp.Core.BLL.DTO.Bid
{
    public class BidDetailsDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImgSrc { get; set; }
        public decimal BuyNowPrice { get; set; }
        public string OwnerUsername { get; set; }
        public string Subcategory { get; set; }
        public string Payment { get; set; }
        public decimal PaymentCost { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public decimal MyOfferPrice { get; set; }
        public DateTime MyOfferPlaced { get; set; }
    }
}