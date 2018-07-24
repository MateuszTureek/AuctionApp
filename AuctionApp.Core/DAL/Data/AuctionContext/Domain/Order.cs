using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Order
    {
        public Order()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Date { get; set; }
        public string BuyerId { get; set; }

        public List<Item> Items { get; }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}
