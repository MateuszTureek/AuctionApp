using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Order
{
    public class CreatedOrderDTO
    {
        public string UserId { get; set; }
        public List<CreatedOrderItemDTO> OrderItems { get; set; }
    }
}
