using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Auction
{
    public class CreateAuctionDTO
    {
        public int ItemId { get; set; }

        [Required]
        [Display(Name="Start auction")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name ="End auction")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
