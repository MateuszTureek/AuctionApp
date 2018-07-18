using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext
{
    public class AuctionInitializer
    {
        UserManager<AppUser> _userManager;
        AuctionDbContext _context;

        public AuctionInitializer(UserManager<AppUser> userManager, AuctionDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (_context.Categories.Any() &&
                _context.DeliveryMethods.Any() &&
                _context.Items.Any())
            {
                return;
            }

            AppUser buyer = _userManager.FindByNameAsync("buyer_1").Result;
            AppUser seller = _userManager.FindByNameAsync("seller_1").Result;

            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Name="AGD",
                    Position=1
                },
                new Category
                {
                    Name="GSM",
                    Position=2
                },
                new Category
                {
                    Name="Foto",
                    Position=3
                }
            };

            List<Subcategory> subcategories = new List<Subcategory>
            {
                // Category AGD
                new Subcategory
                {
                    Name="AGD-wolnostojące",
                    Position=1,
                    Category=categories[0]
                },
                new Subcategory
                {
                    Name="AGD-do zabudowy",
                    Position=2,
                    Category=categories[0]
                },
                new Subcategory
                {
                    Name="AGD-drobne",
                    Position=3,
                    Category=categories[0]
                },
                // Category GSM
                new Subcategory
                {
                    Name="Smartfony",
                    Position=3,
                    Category=categories[1]
                },
                new Subcategory
                {
                    Name="Telefony",
                    Position=5,
                    Category=categories[1]
                },
                // Category Foto
                new Subcategory
                {
                    Name="Karty pamięci",
                    Position=6,
                    Category=categories[2]
                }
            };

            List<Delivery> deliveryOptions = new List<Delivery>
            {
                new Delivery()
                {
                    Price=0.00M,
                    Name="Odbiór osobisty"
                },
                new Delivery()
                {
                    Price=40.00M,
                    DeliveryTime=48,
                    Name="Kurier"
                }
            };

            List<ItemDescription> descriptions = new List<ItemDescription>
            {
                new ItemDescription
                {
                    Key="Title 1",
                    Value="Description content 1"
                },
                new ItemDescription
                {
                    Key="Title 2",
                    Value="Description content 2"
                },
                new ItemDescription
                {
                    Key="Title 3",
                    Value="Description content 3"
                },
                new ItemDescription
                {
                    Key="Title 4",
                    Value="Description content 4"
                },
                new ItemDescription
                {
                    Key="Title 5",
                    Value="Description content 5"
                },
                new ItemDescription
                {
                    Key="Title 6",
                    Value="Description content 6"
                },
                new ItemDescription
                {
                    Key="Title 7",
                    Value="Description content 7"
                },
                new ItemDescription
                {
                    Key="Title 8",
                    Value="Description content 8"
                },
                new ItemDescription
                {
                    Key="Title 9",
                    Value="Description content 9"
                },
                new ItemDescription
                {
                    Key="Title 10",
                    Value="Description content 10"
                }
            };

            List<Auction> auctions = new List<Auction>
            {
                new Auction
                {
                    StartDate=DateTime.Now.AddDays(-2),
                    EndDate=DateTime.Now.AddDays(10),
                    Bids=new List<Bid>
                    {
                        new Bid()
                        {
                            DatePlaced=DateTime.Now,
                            Username=buyer.UserName,
                            UserId=buyer.Id,
                            BidAmount=200M
                        }
                    }
                },
                new Auction
                {
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now.AddDays(17),
                    Bids=new List<Bid>
                    {
                        new Bid()
                        {
                            DatePlaced=DateTime.Now,
                            Username=buyer.UserName,
                            UserId=buyer.Id,
                            BidAmount=50M
                        }
                    }
                },
                new Auction
                {
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now.AddDays(5),
                    Bids=new List<Bid>
                    {
                        new Bid()
                        {
                            DatePlaced=DateTime.Now,
                            Username=buyer.UserName,
                            UserId=buyer.Id,
                            BidAmount=1200M
                        }
                    }
                },
                new Auction
                {
                    StartDate=DateTime.Now.AddDays(-3),
                    EndDate=DateTime.Now,
                    Bids=new List<Bid>
                    {
                        new Bid()
                        {
                            DatePlaced=DateTime.Now.AddDays(-2),
                            Username=buyer.UserName,
                            UserId=buyer.Id,
                            BidAmount=400M
                        }
                    }
                },
                new Auction
                {
                    EndDate = DateTime.Now.AddDays(10),
                    StartDate=DateTime.Now,
                    Bids=new List<Bid>
                    {
                        new Bid()
                        {
                            DatePlaced=DateTime.Now.AddDays(-5),
                            Username=buyer.UserName,
                            UserId=buyer.Id,
                            BidAmount=300M
                        }
                    }
                }
            };

            List<Item> items = new List<Item>
            {
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[0],descriptions[1]
                    },
                    Name="Item 1",
                    ImgSrc="/images/items/example1.jpg",
                    Subcategory=subcategories[3],
                    ConstPrice=1300,
                    Status=Status.InAuction,
                    Delivery=deliveryOptions[0],
                    Auction=auctions[0],
                    UserName=seller.UserName,
                    UserId=seller.Id
                },
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[0],descriptions[1]
                    },
                    Name="Item 1.1",
                    ImgSrc="/images/items/example1.jpg",
                    Subcategory=subcategories[3],
                    ConstPrice=2000,
                    Status=Status.InAuction,
                    Delivery=deliveryOptions[1],
                    Auction=auctions[1],
                    UserName=seller.UserName,
                    UserId=seller.Id
                },
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[0],descriptions[1]
                    },
                    Name="Item 1.2",
                    ImgSrc="/images/items/example1.jpg",
                    Subcategory=subcategories[3],
                    ConstPrice=400,
                    Status=Status.Waiting,
                    Delivery=deliveryOptions[1],
                    UserName=seller.UserName,
                    UserId=seller.Id,
                    Auction=null
                },
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[2],descriptions[3]
                    },
                    Name="Item 2",
                    ImgSrc="/images/items/example2.jpg",
                    Subcategory=subcategories[4],
                    ConstPrice=800,
                    Status=Status.InAuction,
                    Delivery=deliveryOptions[0],
                    UserName=seller.UserName,
                    UserId=seller.Id,
                    Auction=auctions[4]
                },
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[4],descriptions[5],descriptions[6]
                    },
                    Name="Item 3",
                    ImgSrc="/images/items/example3.jpg",
                    Subcategory=subcategories[0],
                    ConstPrice=678,
                    Status=Status.Waiting,
                    Delivery=deliveryOptions[0],
                    UserName=seller.UserName,
                    UserId=seller.Id,
                    Auction=null
                },
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[7],descriptions[8]
                    },
                    Name="Item 4",
                    ImgSrc="/images/items/example4.jpg",
                    Subcategory=subcategories[0],
                    Status=Status.Waiting,
                    Delivery=deliveryOptions[1],
                    UserName=seller.UserName,
                    UserId=seller.Id,
                    Auction=null
                },
                new Item
                {
                    ItemDescriptions=new List<ItemDescription>
                    {
                        descriptions[9]
                    },
                    Name="Item 5",
                    ImgSrc="/images/items/example5.jpg",
                    Subcategory=subcategories[3],
                    Status=Status.Waiting,
                    Delivery=deliveryOptions[1],
                    Auction=null,
                    UserName=seller.UserName,
                    UserId=seller.Id
                },
                new Item
                {
                    ItemDescriptions=null,
                    Name="Item 6",
                    ImgSrc="/images/items/example6.jpg",
                    Subcategory=subcategories[5],
                    ConstPrice=3200,
                    Status=Status.Bought,
                    Delivery=deliveryOptions[1],
                    Auction=auctions[3],
                    UserName=seller.UserName,
                    UserId=seller.Id
                }
            };
            
            foreach (var item in items)
            {
                _context.Items.Add(item);
            }
            _context.SaveChanges();

            foreach (var auction in auctions)
            {
                auction.SetBestBidId();
            }
            _context.SaveChanges();
        }
    }
}