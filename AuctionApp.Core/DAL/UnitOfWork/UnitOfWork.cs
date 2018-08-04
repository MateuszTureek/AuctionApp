using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.UnitOfWork.Contract;

namespace AuctionApp.Core.DAL.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        readonly AuctionDbContext _dbContext;
        readonly IBidRepo _bidRepo;
        readonly ICategoryRepo _categoryRepo;
        readonly IItemRepo _itemRepo;
        readonly IOrderRepo _orderRepo;
        readonly IPaymentRepo _paymentRepo;

        public UnitOfWork (
            AuctionDbContext dbContext,
            IBidRepo bidRepo,
            ICategoryRepo categoryRepo,
            IItemRepo itemRepo,
            IOrderRepo orderRepo,
            IPaymentRepo paymentRepo
        ) {
            _dbContext = dbContext;
            _bidRepo = bidRepo;
            _categoryRepo = categoryRepo;
            _itemRepo = itemRepo;
            _orderRepo = orderRepo;
            _paymentRepo = paymentRepo;
        }

        public IBidRepo BidRepo => _bidRepo;

        public ICategoryRepo CategoryRepo => _categoryRepo;

        public IItemRepo ItemRepo => _itemRepo;

        public IOrderRepo OrderRepo => _orderRepo;

        public IPaymentRepo PaymentRepo => _paymentRepo;

        public void Save () {
            _dbContext.SaveChanges ();
        }
    }
}