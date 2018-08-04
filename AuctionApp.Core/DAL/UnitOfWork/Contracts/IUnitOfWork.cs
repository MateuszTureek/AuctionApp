using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.UnitOfWork.Contract
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
