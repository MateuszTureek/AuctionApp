using AuctionApp.Core.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Areas.customer.Models.Item
{
    public class NewItemViewModel
    {
        [Required(ErrorMessage = "Pole {0} jest wymagane.")]
        [Display(Name = "Nazwa")]
        [StringLength(50, ErrorMessage = "Max. liczba znaków {1}.")]
        public string Name { get; set; }

        [Display(Name = "Cena kup teraz")]
        public decimal? ConstPrice { get; set; }

        public int CatId { get; set; }
        [Display(Name = "Kategoria")]
        public List<SelectListItem> Categories { get; set; }

        public int SubcatId { get; set; }
        [Display(Name = "Podkategoria")]
        public List<SelectListItem> Subcategories { get; set; }

        public int MethId { get; set; }
        [Display(Name = "Dostawa")]
        public List<SelectListItem> DeliverMethods { get; set; }

        public List<DescriptionDTO> Descriptions { get; set; }

        public IFormFile File { get; set; }
    }
}