using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Core.DAL.Data.AuctionContext {
    public class AuctionDbContext : DbContext {
        public AuctionDbContext (DbContextOptions<AuctionDbContext> options) : base (options) { }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDescription> ItemDescriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Order> (order => {
                order.HasKey (k => k.Id);
                order.Property (p => p.BuyerId).IsRequired ().HasMaxLength (450);
                order.Property (p => p.Date).IsRequired ();
                order.Property (p => p.TotalCost).IsRequired ().HasColumnType ("decimal(16,2)");

                order.HasMany (m => m.Items).WithOne (o => o.Order).HasForeignKey (f => f.OrderId).IsRequired (false);
            });

            modelBuilder.Entity<Item> (item => {
                item.HasKey (k => k.Id);
                item.Property (p => p.Name).HasMaxLength (50).IsRequired ();
                item.Property (p => p.ImgSrc).IsRequired ();
                item.Property (p => p.ConstPrice).HasColumnType ("decimal(16,2)");
                item.Property (p => p.Status).IsRequired ();
                item.Property (p => p.AuctionStart).IsRequired (false);
                item.Property (p => p.AuctionEnd).IsRequired (false);
                item.Property (p => p.UserId).HasMaxLength (450).IsRequired ();

                item.HasMany (m => m.Bids).WithOne (o => o.Item).HasForeignKey (f => f.ItemRef).IsRequired (false);
                item.HasMany (m => m.ItemDescriptions).WithOne (o => o.Item).HasForeignKey (f => f.ItemRef).IsRequired (false);
            });

            modelBuilder.Entity<Bid> (bid => {
                bid.HasKey (k => k.Id);
                bid.Property (p => p.BidAmount).HasColumnType ("decimal(16,2)").IsRequired ();
                bid.Property (p => p.DatePlaced).IsRequired ();
                bid.Property (p => p.UserId).HasMaxLength (450).IsRequired ();
                bid.Property (p => p.Username).HasMaxLength (250).IsRequired ();
            });

            modelBuilder.Entity<Category> (cat => {
                cat.HasKey (k => k.Id);
                cat.Property (p => p.Name).HasMaxLength (50).IsRequired ();
                cat.Property (p => p.Position).IsRequired ();

                cat.HasMany (m => m.Subcategories).WithOne (o => o.Category).HasForeignKey (f => f.CategoryRef).OnDelete (DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Payment> (payment => {
                payment.HasKey (k => k.Id);
                payment.Property (p => p.Name).HasMaxLength (50).IsRequired ();
                payment.Property (p => p.Cost).HasColumnType ("decimal(16,2)").IsRequired ();

                payment.HasMany (m => m.Items).WithOne (o => o.Payment).HasForeignKey (f => f.PaymentRef);
            });

            modelBuilder.Entity<ItemDescription> (itemDesc => {
                itemDesc.HasKey (k => k.Id);
                itemDesc.Property (p => p.Key).HasMaxLength (80).IsRequired ();
                itemDesc.Property (p => p.Value).IsRequired ();
            });

            modelBuilder.Entity<Subcategory> (cat => {
                cat.HasKey (k => k.Id);
                cat.Property (p => p.Name).HasMaxLength (50).IsRequired ();
                cat.Property (p => p.Position).IsRequired ();

                cat.HasMany (m => m.Items).WithOne (o => o.Subcategory).HasForeignKey (f => f.SubcategoryRef);
            });
        }
    }
}