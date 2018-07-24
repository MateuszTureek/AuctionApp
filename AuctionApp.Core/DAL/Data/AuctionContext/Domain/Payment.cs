using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Payment
    {
        public Payment()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public List<Item> Items { get; }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}
