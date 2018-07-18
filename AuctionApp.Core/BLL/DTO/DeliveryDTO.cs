using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Price { get; set; }
    }
}
