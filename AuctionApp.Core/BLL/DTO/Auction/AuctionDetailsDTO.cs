using AuctionApp.Core.BLL.DTO.Bid;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Auction
{
    public class AuctionDetailsDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal PriceBuyNow { get; set; }
        public string UserNameOfSeller { get; set; }
        public string ImgSrc { get; set; }
        public string Delivery { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<AuctionBidDTO> AuctionBids { get; set; }
    }
}
