using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public class ItemBidViewModel
    {
        [Display(Name ="Oferta")]
        public decimal BidAmount { get; set; }

        [Display(Name ="Dodano")]
        public DateTime DatePlaced { get; set; }

        [Display(Name ="Użytkownik")]
        public string Username { get; set; }
    }
}
