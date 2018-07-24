using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
