﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Subcategory
    {
        public Subcategory()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short Position { get; set; }

        public int CategoryRef { get; set; }
        public Category Category { get; set; }

        public List<Item> Items { get; set; }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}
