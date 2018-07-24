using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public abstract class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgSrc { get; set; }
    }

    public class ItemDetailsViewModel : ItemViewModel
    {
        [Display(Name = "Cena")]
        public decimal BuyNowPrice { get; set; }

        public DateTime AuctionEndDate { get; set; }

        [Display(Name = "Płatność")]
        public string Payment { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }

        public List<DescriptionDTO> Descriptions { get; set; }

        public List<ItemBidViewModel> Bids { get; set; }

        public string UserNameOfOwner { get; set; }
    }

    public class SimpleItemViewModel : ItemViewModel
    {
        [Display(Name = "Płatność")]
        public string Payment { get; set; }

        [Display(Name = "Kup teraz")]
        public decimal BuyNowPrice { get; set; }
    }

    public class PagedItemViewModel
    {
        public int TotalPages { get; set; }
        public List<SimpleItemViewModel> Items { get; set; }
    }

    public class PagedItemCriteriaViewModel
    {
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public int? PageNumber { get; set; }
        public SortBy SortBy { get; set; }
    }
}
