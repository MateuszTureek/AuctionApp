﻿using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
            : base(options) { }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDescription> ItemDescriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ClientItem> ClientItems { get; set; }
        public DbSet<ClientBid> ClientBids { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>(bid =>
            {
                bid.HasKey(k => k.Id);
                bid.Property(p => p.BidAmount).HasColumnType("decimal(16,2)").IsRequired();
                bid.Property(p => p.DatePlaced).IsRequired();
            });

            modelBuilder.Entity<Category>(cat =>
            {
                cat.HasKey(k => k.Id);
                cat.Property(p => p.Name).HasMaxLength(50).IsRequired();
                cat.Property(p => p.Position).IsRequired();
            });

            modelBuilder.Entity<Payment>(payment =>
            {
                payment.HasKey(k => k.Id);
                payment.Property(p => p.Name).HasMaxLength(50).IsRequired();
                payment.Property(p => p.DeliveryTime).IsRequired();
                payment.Property(p => p.Amount).IsRequired();
            });

            modelBuilder.Entity<Item>(item =>
            {
                item.HasKey(k => k.Id);
                item.Property(p => p.Name).HasMaxLength(50).IsRequired();
                item.Property(p => p.AuctionEndDate).IsRequired();
                item.Property(p => p.ImgSrc).IsRequired();
                item.Property(p => p.BuyNowPrice).HasColumnType("decimal(16,2)");
            });

            modelBuilder.Entity<ItemDescription>(itemDesc =>
            {
                itemDesc.HasKey(k => k.Id);
                itemDesc.Property(p => p.Key).HasMaxLength(80).IsRequired();
                itemDesc.Property(p => p.Value).IsRequired();
            });

            modelBuilder.Entity<Subcategory>(cat =>
            {
                cat.HasKey(k => k.Id);
                cat.Property(p => p.Name).HasMaxLength(50).IsRequired();
                cat.Property(p => p.Position).IsRequired();
            });

            modelBuilder.Entity<ClientItem>(cItem =>
            {
                cItem.HasKey(k => k.ItemId);
                cItem.Property(p => p.UserId).IsRequired().HasMaxLength(450);
            });

            modelBuilder.Entity<ClientBid>(cBid =>
            {
                cBid.HasKey(k => k.BidId);
                cBid.Property(p => p.UserId).IsRequired().HasMaxLength(450);
            });

            // relations
            modelBuilder.Entity<Bid>().HasMany(m => m.ClientBids).WithOne(o => o.Bid).HasForeignKey("BidId");

            modelBuilder.Entity<Item>(item =>
            {
                item.HasMany(m => m.Bids).WithOne(o => o.Item);
                item.HasMany(m => m.Descriptions).WithOne(o => o.Item);
                item.HasOne(o => o.Subcategory).WithMany(m => m.Items);
                item.HasMany(m => m.ClientItems).WithOne(o => o.Item).HasForeignKey("ItemId");
                item.HasOne(o => o.Payment).WithMany(m => m.Items).HasForeignKey("PaymentId");
            });
            modelBuilder.Entity<Category>().HasMany(m => m.Subcategories).WithOne(o => o.Category);
        }
    }
}
