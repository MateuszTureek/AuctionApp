using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Strategy.AuctionOrderBy;
using AuctionApp.Core.DAL.Criteria;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class AuctionService : IAuctionService
    {
        readonly IMapper _mapper;
        readonly IAuctionRepo _auctionRepo;
        readonly IPaginationService _paginationService;

        public AuctionService(IMapper mapper,
                              IPaginationService paginationService,
                              IAuctionRepo auctionRepo,
                              IAuctionContext auctionContext)
        {
            _paginationService = paginationService;
            _auctionRepo = auctionRepo;
            _mapper = mapper;
        }

        public int GetAmountOfPages(int pageSize)
        {
            var auctionCount = _auctionRepo.GetCount();
            double amountOfPages = 0;

            try
            {
                amountOfPages = Math.Ceiling((double)auctionCount / (double)pageSize);
            }
            catch (DivideByZeroException)
            {
                // handle that
            }
            return Convert.ToInt32(amountOfPages);
        }

        public List<AuctionDTO> GetAuctions(FilterAuctionDTO dto)
        {
            AuctionContext context;

            if (dto.CategoryId != null)
            {
                switch (dto.SortBy)
                {
                    case SortBy.EndDateAuction:
                        {
                            context = new AuctionContext(new AuctionByCategoryOrderByEndDateStartegy(_paginationService, _auctionRepo));
                            break;
                        }
                    case SortBy.PriceBuyNow:
                        {
                            context = new AuctionContext(new AuctionByCategoryOrderByPriceBuyNowStartegy(_paginationService, _auctionRepo));
                            break;
                        }
                    default:
                        {
                            context = new AuctionContext(new AuctionByCategoryOrderByNameStartegy(_paginationService, _auctionRepo));
                            break;
                        }
                }
            }
            else
            {
                if (dto.SubcategoryId != null)
                {
                    switch (dto.SortBy)
                    {
                        case SortBy.EndDateAuction:
                            {
                                context = new AuctionContext(new AuctionBySubcategoryOrderByEndDateStartegy(_paginationService,_auctionRepo));
                                break;
                            }
                        case SortBy.PriceBuyNow:
                            {
                                context = new AuctionContext(new AuctionBySubcategoryOrderByPriceBuyNowStartegy(_paginationService, _auctionRepo));
                                break;
                            }
                        default:
                            {
                                context = new AuctionContext(new AuctionBySubcategoryOrderByNameStartegy(_paginationService, _auctionRepo));
                                break;
                            }
                    }
                }
                else
                {
                    switch (dto.SortBy)
                    {
                        case SortBy.EndDateAuction:
                            {
                                context = new AuctionContext(new AuctionOrderByEndDateStrategy(_paginationService, _auctionRepo));
                                break;
                            }
                        case SortBy.PriceBuyNow:
                            {
                                context = new AuctionContext(new AuctionOrderByPriceBuyNowStrategy(_paginationService, _auctionRepo));
                                break;
                            }
                        default:
                            {
                                context = new AuctionContext(new AuctionOrderByNameStrategy(_paginationService, _auctionRepo));
                                break;
                            }
                    }
                }
            }

            var auctions = context.GetAuctions(dto);
            return _mapper.Map<List<Item>, List<AuctionDTO>>(auctions);
        }

        public List<LatestAuctionDTO> TakeAuctions(int amount, bool actived)
        {
            var auctions = _auctionRepo.TakeAuctions(4, actived).ToList();

            return _mapper.Map<List<Item>, List<LatestAuctionDTO>>(auctions);
        }
    }
}