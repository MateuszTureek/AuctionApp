using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Static;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.BLL.Strategy.AuctionOrderBy
{
    public class AuctionByCategoryOrderByPriceBuyNowStartegy : IStrategy
    {
        readonly IAuctionRepo _auctionRepo;
        readonly IPaginationService _paginationService;

        public AuctionByCategoryOrderByPriceBuyNowStartegy(IPaginationService paginationService,
                                                           IAuctionRepo auctionRepo)
        {
            _paginationService = paginationService;
            _auctionRepo = auctionRepo;
        }

        public List<Item> GetAuctionsOrderBy(FilterItemDTO dto)
        {
            PaginationService.PageNumber = dto.PageNumber;
            PaginationService.TotalCount = _auctionRepo.TakeAuctionsTotalCount(s => s.BuyNowPrice,
                s => s.Subcategory.Category.Id == dto.CategoryId && s.Activated == true);

            int skip = _paginationService.CalcToSkip();

            return _auctionRepo.TakeAuctions(s => s.BuyNowPrice,
                s => s.Subcategory.Category.Id == dto.CategoryId,
                skip,
                dto.PageSize).ToList();
        }
    }
}
