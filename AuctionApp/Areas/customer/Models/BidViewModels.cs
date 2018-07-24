using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Areas.customer.Models
{
    public class ItemBidViewModel
    {
        [Display(Name = "Oferta")]
        public decimal BidAmount { get; set; }

        [Display(Name = "Dodano")]
        public DateTime DatePlaced { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }
    }

    public class BidDetailsViewModel
    {
        public int ItemId { get; set; }

        [Display(Name="Przedmiot")]
        public string ItemName { get; set; }
        
        public string ImgSrc { get; set; }

        [Display(Name="Kup teraz - cena")]
        public decimal BuyNowPrice { get; set; }

        [Display(Name="Sprzedający")]
        public string OwnerUsername { get; set; }

        [Display(Name="Kategoria")]
        public string Subcategory { get; set; }

        [Display(Name="Płatnosc")]
        public string Payment { get; set; }

        [Display(Name="Koszt platnosci")]
        public decimal PaymentCost { get; set; }

        [Display(Name="Rozpoczecie aukcji")]
        public DateTime AuctionStart { get; set; }

        [Display(Name="Zakonczenie aukcji")]
        public DateTime AuctionEnd { get; set; }

        [Display(Name="Moja oferta")]
        public decimal MyOfferPrice { get; set; }
        
        [Display(Name="Dodano")]
        public DateTime MyOfferPlaced { get; set; }
    }
}
