using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Bid
{
    public class NewBidDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal BestBidPrice { get; set; }
        public decimal MyBid { get; set; }
        public string Username { get; set; }
    }
}
