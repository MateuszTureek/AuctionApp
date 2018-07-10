﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeliveryTime { get; set; }
        public decimal Price { get; set; }

        public IList<Item> Items { get; set; }
    }
}