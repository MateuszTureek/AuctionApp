using System;
using System.Collections.Generic;
using System.Text;
using AuctionApp.Core.DAL.Repository.Contract;

namespace AuctionApp.Core.DAL.UnitOfWork.Contract {
    public interface IUnitOfWork {
        IBidRepo BidRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        IItemRepo ItemRepo { get; }
        IOrderRepo OrderRepo { get; }
        IPaymentRepo PaymentRepo { get; }
        void Save ();
    }
}