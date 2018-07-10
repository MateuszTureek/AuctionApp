using AuctionApp.Core.BLL.DTO.Bid;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class ItemDetailsDTO : ItemDTO
    {
        public DateTime AuctionEndDate { get; set; }
        public string DeliveryMethod { get; set; }
        public Status Status { get; set; }

        public List<DescriptionDTO> Descriptions { get; set; }
        public List<BidOfAuctionDTO> Bids { get; set; }
        public AuctionApp.Core.DAL.Data.AuctionContext.Domain.Auction Auction { get; set; }
    }
}
