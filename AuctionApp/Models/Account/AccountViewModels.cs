using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AuctionApp.Models.Account {
    public class RegisterViewModel {
        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength (30, ErrorMessage = "Max. liczba znaków {1}.")]
        [Display (Name = "Imie")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength (50, ErrorMessage = "Max. liczba znaków {1}.")]
        [Display (Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [Display (Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength (150, ErrorMessage = "Max. liczba znaków {1}.")]
        [Display (Name = "Adres")]
        public string Address { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [MaxLength (80, ErrorMessage = "Max. liczba znaków {1}.")]
        [Display (Name = "Kraj")]
        public string Country { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [Display (Name = "Login")]
        [MaxLength (256, ErrorMessage = "Max. liczba znaków {1}.")]
        public string Username { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [Display (Name = "E-mail")]
        [MaxLength (256, ErrorMessage = "Max. liczba znaków {1}.")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [Display (Name = "Hasło")]
        public string Password { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [Compare ("Password")]
        [Display (Name = "Powtórz hasło")]
        public string ConfirmPassword { get; set; }
        public IFormFile File { get; set; }
    }

    public class LoginViewModel {
        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [Display (Name = "Login")]
        [MaxLength (256, ErrorMessage = "Max. liczba znaków {1}.")]
        public string Username { get; set; }

        [Required (ErrorMessage = "Pole {0} jest wymagane.")]
        [Display (Name = "Hasło")]
        public string Password { get; set; }

        [Display (Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}