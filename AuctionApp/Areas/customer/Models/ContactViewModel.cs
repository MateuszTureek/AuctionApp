using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Areas.customer.Models
{
    public class ContactViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Display(Name = "Imie")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(30)]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(150)]
        public string Address { get; set; }

        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength(80)]
        public string Country { get; set; }

        public string PhotoSrc { get; set; }
    }
}