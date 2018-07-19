using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class NewItemDTO
    {
        public string Name { get; set; }
        public decimal? ConstPrice { get; set; }
        public int CatId { get; set; }
        public int SubcatId { get; set; }
        public int MethId { get; set; }
        public IFormFile File { get; set; }
        public List<DescriptionDTO> Descriptions { get; set; }
    }
}
