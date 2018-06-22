using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class SingleAuctionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Activated { get; set; }
        public DateTime AuctionEndDate { get; set; }
        public string ImgSrc { get; set; }
        public decimal BuyNowPrice { get; set; }

        public List<DescriptionDTO> Descriptions { get; set; }
        public List<BidOfAuction> Bids { get; set; }
    }
}
