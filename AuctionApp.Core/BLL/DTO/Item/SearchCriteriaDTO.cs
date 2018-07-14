using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.DTO.Item
{
    public class SearchCriteriaDTO
    {
        public int AmountOfPages { get; set; }
        public string Phrase { get; set; }
        public int PageIndex { get; set; }
    }
}
