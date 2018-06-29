using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class ItemDetailsDTO : ItemDTO
    {
        public DateTime AuctionEndDate { get; set; }
        public string PaymentMethod { get; set; }
        public Status Status { get; set; }

        public List<DescriptionDTO> Descriptions { get; set; }
        public List<BidOfAuction> Bids { get; set; }
    }
}
