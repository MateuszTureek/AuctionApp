using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Core.DAL.Data.AuctionContext {
    public class AuctionInitializer {
        UserManager<AppUser> _userManager;
        AuctionDbContext _context;

        public AuctionInitializer (UserManager<AppUser> userManager, AuctionDbContext context) {
            _userManager = userManager;
            _context = context;
        }

        public void Initialize () {
            _context.Database.EnsureCreated ();

            if (_context.Categories.Any () &&
                _context.Payments.Any () &&
                _context.Items.Any ()) {
                return;
            }

            AppUser buyer = _userManager.FindByNameAsync ("buyer_1").Result;
            AppUser seller = _userManager.FindByNameAsync ("seller_1").Result;

            List<Subcategory> subcategories = new List<Subcategory> {
                // Category AGD
                new Subcategory {
                Name = "AGD-wolnostojące",
                Position = 1
                },
                new Subcategory {
                Name = "AGD-do zabudowy",
                Position = 2
                },
                new Subcategory {
                Name = "AGD-drobne",
                Position = 3
                },
                // Category GSM
                new Subcategory {
                Name = "Smartfony",
                Position = 3
                },
                new Subcategory {
                Name = "Telefony",
                Position = 5
                },
                // Category Foto
                new Subcategory {
                Name = "Karty pamięci",
                Position = 6
                }
            };

            List<Category> categories = new List<Category> {
                new Category {
                Name = "AGD",
                Position = 1
                },
                new Category {
                Name = "GSM",
                Position = 2
                },
                new Category {
                Name = "Foto",
                Position = 3
                }
            };
            categories[0].AddSubcategory (subcategories[0]);
            categories[0].AddSubcategory (subcategories[1]);
            categories[0].AddSubcategory (subcategories[2]);
            categories[1].AddSubcategory (subcategories[3]);
            categories[1].AddSubcategory (subcategories[4]);
            categories[2].AddSubcategory (subcategories[5]);
            foreach (var item in categories) {
                _context.Categories.Add (item);
            }
            _context.SaveChanges ();

            List<ItemDescription> descriptions = new List<ItemDescription> {
                new ItemDescription {
                Key = "Title 1",
                Value = "Description content 1"
                },
                new ItemDescription {
                Key = "Title 2",
                Value = "Description content 2"
                },
                new ItemDescription {
                Key = "Title 3",
                Value = "Description content 3"
                },
                new ItemDescription {
                Key = "Title 4",
                Value = "Description content 4"
                },
                new ItemDescription {
                Key = "Title 5",
                Value = "Description content 5"
                },
                new ItemDescription {
                Key = "Title 6",
                Value = "Description content 6"
                },
                new ItemDescription {
                Key = "Title 7",
                Value = "Description content 7"
                },
                new ItemDescription {
                Key = "Title 8",
                Value = "Description content 8"
                },
                new ItemDescription {
                Key = "Title 9",
                Value = "Description content 9"
                },
                new ItemDescription {
                Key = "Title 10",
                Value = "Description content 10"
                }
            };

            List<Bid> bids = new List<Bid> {
                new Bid {
                BidAmount = 350M,
                DatePlaced = DateTime.Now.AddDays (3),
                UserId = buyer.Id,
                Username = buyer.UserName
                },
                new Bid {
                BidAmount = 1200M,
                DatePlaced = DateTime.Now.AddDays (2),
                UserId = buyer.Id,
                Username = buyer.UserName
                }
            };

            List<Item> items = new List<Item> {
                new Item {
                Name = "Item 1",
                ImgSrc = "/images/items/example1.jpg",
                Subcategory = subcategories[3],
                ConstPrice = 1300,
                Status = Status.InAuction,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now.AddDays (2),
                AuctionEnd = DateTime.Now.AddDays (6),
                Order = null
                },
                new Item {
                Name = "Item 1.1",
                ImgSrc = "/images/items/example1.jpg",
                Subcategory = subcategories[3],
                ConstPrice = 2000,
                Status = Status.InAuction,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now.AddDays (8),
                Order = null
                },
                new Item {
                Name = "Item 1.2",
                ImgSrc = "/images/items/example1.jpg",
                Subcategory = subcategories[3],
                ConstPrice = 400,
                Status = Status.Waiting,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now.AddDays (4),
                AuctionEnd = DateTime.Now.AddDays (10),
                Order = null
                },
                new Item {
                Name = "Item 2",
                ImgSrc = "/images/items/example2.jpg",
                Subcategory = subcategories[4],
                ConstPrice = 800,
                Status = Status.InAuction,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now.AddDays (10),
                Order = null
                },
                new Item {
                Name = "Item 3",
                ImgSrc = "/images/items/example3.jpg",
                Subcategory = subcategories[0],
                ConstPrice = 678,
                Status = Status.Waiting,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now.AddDays (10),
                AuctionEnd = DateTime.Now.AddDays (12),
                Order = null
                },
                new Item {
                Name = "Item 4",
                ImgSrc = "/images/items/example4.jpg",
                Subcategory = subcategories[0],
                Status = Status.Waiting,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now,
                AuctionEnd = DateTime.Now.AddDays (3)
                },
                new Item {
                Name = "Item 5",
                ImgSrc = "/images/items/example5.jpg",
                Subcategory = subcategories[3],
                Status = Status.Waiting,
                UserId = seller.Id,
                Username = seller.UserName,
                AuctionStart = DateTime.Now.AddDays (2),
                AuctionEnd = DateTime.Now.AddDays (12)
                },
                new Item {
                Name = "Item 6",
                ImgSrc = "/images/items/example6.jpg",
                Subcategory = subcategories[5],
                ConstPrice = 3200,
                Status = Status.Bought,
                Username = seller.UserName,
                UserId = seller.Id,
                AuctionStart = null,
                AuctionEnd = null,
                }
            };
            items[0].AddDescription (descriptions[0]);
            items[0].AddDescription (descriptions[1]);
            items[1].AddDescription (descriptions[2]);
            items[2].AddDescription (descriptions[3]);
            items[2].AddDescription (descriptions[4]);
            items[3].AddDescription (descriptions[5]);
            items[4].AddDescription (descriptions[6]);
            items[5].AddDescription (descriptions[7]);
            items[5].AddDescription (descriptions[8]);
            items[6].AddDescription (descriptions[9]);

            items[0].AddBid (bids[0]);
            items[1].AddBid (bids[1]);

            foreach (var item in items) {
                _context.Items.Add (item);
            }
            _context.SaveChanges ();

            List<Payment> payments = new List<Payment> {
                new Payment () {
                Cost = 0.00M,
                Name = "Przelew"
                },
                new Payment () {
                Cost = 40.00M,
                Name = "Przy odbiorze"
                }
            };
            payments[0].AddItem (items[0]);
            payments[0].AddItem (items[2]);
            payments[0].AddItem (items[6]);
            payments[1].AddItem (items[1]);
            payments[1].AddItem (items[3]);
            payments[1].AddItem (items[4]);
            payments[1].AddItem (items[5]);
            payments[1].AddItem (items[7]);
            foreach (var item in payments) {
                _context.Payments.Add (item);
            }
            _context.SaveChanges ();

            Order o1 = new Order {
                BuyerId = buyer.Id,
                Date = DateTime.Now,
                TotalCost = payments[1].Cost + 3200
            };
            o1.Items.Add (items[7]);

            _context.Orders.Add (o1);
            _context.SaveChanges ();
        }
    }
}