using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Service.Contract;
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

        public AuctionService(IMapper mapper,
                              IAuctionRepo auctionRepo)
        {
            _auctionRepo = auctionRepo;
            _mapper = mapper;
        }

        public List<AuctionDTO> TakeAuctions(int amount, bool actived)
        {
            var auctions = _auctionRepo.Take(4, actived).ToList();
            return _mapper.Map<List<Item>, List<AuctionDTO>>(auctions);
        }
    }
}
