﻿using System;
using System.Collections.Generic;
using System.Text;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;

namespace AuctionApp.Core.DAL.Repository.Contract {
    public interface IPaymentRepo : IGenericRepo<Payment> { }
}