﻿using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
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

            if (_context.Categories.Any())
            {
                return;
            }

            AppUser buyer = _userManager.FindByNameAsync("buyer_1").Result;
            AppUser seller = _userManager.FindByNameAsync("seller_1").Result;

            List<Subcategory> subcategories = new List<Subcategory>
            {
                // Category AGD
                new Subcategory
                {
                    Name="AGD-wolnostojące",
                    Position=1
                },
                new Subcategory
                {
                    Name="AGD-do zabudowy",
                    Position=2
                },
                new Subcategory
                {
                    Name="AGD-drobne",
                    Position=3
                },
                // Category GSM
                new Subcategory
                {
                    Name="Smartfony",
                    Position=3
                },
                new Subcategory
                {
                    Name="Telefony",
                    Position=5
                },
                // Category Foto
                new Subcategory
                {
                    Name="Karty pamięci",
                    Position=6
                }
            };

            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Name="AGD",
                    Position=1,
                    Subcategories=new List<Subcategory>{ subcategories[0], subcategories[1], subcategories[2] }
                },
                new Category
                {
                    Name="GSM",
                    Position=2,
                    Subcategories=new List<Subcategory>{ subcategories[3], subcategories[4] }
                },
                new Category
                {
                    Name="Foto",
                    Position=3,
                    Subcategories=new List<Subcategory>{ subcategories[5] }
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

            List<Item> items = new List<Item>
            {
                new Item
                {
                    Activated=true,
                    AuctionEndDate=DateTime.Now.AddDays(12),
                    Descriptions=new List<ItemDescription>
                    {
                        descriptions[0],descriptions[1]
                    },
                    Name="Item 1",
                    ImgSrc="/images/items/example1.jpg",
                    Subcategory=subcategories[3],
                    BuyNowPrice=2000
                },
                new Item
                {
                    Activated=true,
                    AuctionEndDate=DateTime.Now.AddDays(4),
                    Descriptions=new List<ItemDescription>
                    {
                        descriptions[2],descriptions[3]
                    },
                    Name="Item 2",
                    ImgSrc="/images/items/example2.jpg",
                    Subcategory=subcategories[4],
                    BuyNowPrice=800
                },
                new Item
                {
                    Activated=false,
                    AuctionEndDate=DateTime.Now.AddDays(20),
                    Descriptions=new List<ItemDescription>
                    {
                        descriptions[4],descriptions[5],descriptions[6]
                    },
                    Name="Item 3",
                    ImgSrc="/images/items/example3.jpg",
                    Subcategory=subcategories[0],
                    BuyNowPrice=678
                },
                new Item
                {
                    Activated=true,
                    AuctionEndDate=DateTime.Now.AddDays(-1),
                    Descriptions=new List<ItemDescription>
                    {
                        descriptions[7],descriptions[8]
                    },
                    Name="Item 4",
                    ImgSrc="/images/items/example4.jpg",
                    Subcategory=subcategories[0]
                },
                new Item
                {
                    Activated=false,
                    AuctionEndDate=DateTime.Now.AddDays(-10),
                    Descriptions=new List<ItemDescription>
                    {
                        descriptions[9]
                    },
                    Name="Item 5",
                    ImgSrc="/images/items/example5.jpg",
                    Subcategory=subcategories[3]
                },
                new Item
                {
                    Activated=true,
                    AuctionEndDate=DateTime.Now.AddDays(30),
                    Descriptions=null,
                    Name="Item 6",
                    ImgSrc="/images/items/example6.jpg",
                    Subcategory=subcategories[5],
                    BuyNowPrice=3200
                }
            };

            List<Bid> bids = new List<Bid>
            {
                new Bid
                {
                    BidAmount=100,
                    DatePlaced=DateTime.Now,
                    Item=items[0]
                },
                new Bid
                {
                    BidAmount=150,
                    DatePlaced=DateTime.Now,
                    Item=items[1]
                },
                new Bid
                {
                    BidAmount=580,
                    DatePlaced=DateTime.Now,
                    Item=items[2]
                }
            };

            List<ClientItem> clientItems = new List<ClientItem>
            {
                new ClientItem
                {
                    Item=items[0],
                    UserId=seller.Id
                },
                new ClientItem
                {
                    Item=items[1],
                    UserId=seller.Id
                },
                new ClientItem
                {
                    Item=items[2],
                    UserId=seller.Id
                },
                new ClientItem
                {
                    Item=items[3],
                    UserId=seller.Id
                },
                new ClientItem
                {
                    Item=items[4],
                    UserId=seller.Id
                },
                new ClientItem
                {
                    Item=items[5],
                    UserId=seller.Id
                }
            };

            List<ClientBid> clientBids = new List<ClientBid>
            {
                new ClientBid
                {
                    Bid=bids[0],
                    UserId=buyer.Id
                },
                new ClientBid
                {
                    Bid=bids[1],
                    UserId=buyer.Id
                },
                new ClientBid
                {
                    Bid=bids[2],
                    UserId=buyer.Id
                }
            };

            foreach (var c in categories)
            {
                _context.Categories.Add(c);
            }
            _context.SaveChanges();

            foreach (var b in bids)
            {
                _context.Bids.Add(b);
            }
            _context.SaveChanges();

            foreach (var cItem in clientItems)
            {
                _context.ClientItems.Add(cItem);
            }
            _context.SaveChanges();

            foreach (var cBid in clientBids)
            {
                _context.ClientBids.Add(cBid);
            }
            _context.SaveChanges();
        }
    }
}