using AuctionApp.Attributes.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public class NewBidViewModel
    {
        [HiddenInput]
        public int ItemId { get; set; }

        [Display(Name = "Przedmiot:")]
        public string ItemName { get; set; }

        [Display(Name = "Bieżąca:")]
        public decimal BestBidPrice { get; set; }

        [Required]
        [Display(Name = "Moja oferta:")]
        [MyPriceGreaterThanBestBidPrice("BestBidPrice", ErrorMessage = "Twoja oferta musi być wieksza od bieżącej ofety.")]
        public decimal MyBid { get; set; }
    }
}
